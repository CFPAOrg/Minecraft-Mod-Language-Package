using System;
using System.Collections.Generic;
using System.IO;

using Packer.Extensions;
using Serilog;

namespace Packer.Models
{
    /// <summary>
    /// 标志文件类型的枚举。目前而言有[是否按.json]和[是否按\lang\]两类
    /// </summary>
    [Flags]
    public enum FileCategory
    {
        /// <summary>
        /// 仅用于初始化为默认态
        /// </summary>
        None = 0,
        /// <summary>
        /// 类 .json，标识需要转义与 json 式序列化
        /// </summary>
        JsonAlike = 1,
        /// <summary>
        /// 类 .lang，标识无需转义与 lang 式序列化
        /// </summary>
        LangAlike = 2,
        /// <summary>
        /// 位于 /lang/ 中的文件，进行合并等
        /// </summary>
        LanguageFile = 4,
        /// <summary>
        /// 位于其余位置的文件，不进行合并
        /// </summary>
        OtherFiles = 8,
        /// <summary>
        /// */lang/*.json
        /// </summary>
        JsonTranslationFormat = JsonAlike | LanguageFile,
        /// <summary>
        /// */lang/*.lang
        /// </summary>
        LangTranslationFormat = LangAlike | LanguageFile,
        /// <summary>
        /// */[not-lang]/*.json
        /// </summary>
        JsonOthers = JsonAlike | OtherFiles,
        /// <summary>
        /// */[not-lang]/*.lang
        /// </summary>
        LangOthers = LangAlike | OtherFiles
    }

    /// <summary>
    /// 语言文本的抽象<br></br>
    /// 这是基本类
    /// </summary>
    public class TranslatedFile
    {
        /// <summary>
        /// asset-domain下的位置
        /// </summary>
        public string relativePath;
        /// <summary>
        /// 该文件的文本，用<i>字符串</i>表示<br></br>
        /// 因此，不能存储非文本文件！
        /// </summary>
        public readonly string stringifiedContent;
        /// <summary>
        /// 文件类型
        /// </summary>
        public FileCategory category;
        /// <summary>
        /// 从文件流构造内容
        /// </summary>
        public TranslatedFile(Stream stream, FileCategory category, Config config)
        { // 注：文件流在此处被关闭
            using var reader = new StreamReader(stream);
            stringifiedContent = reader.ReadToEnd().Preprocess(category, config);
            this.category = category;
        }
        /// <summary>
        /// 从文本构造内容
        /// </summary>
        public TranslatedFile(FileCategory category, string content)
        {
            this.category = category;
            stringifiedContent = content;
        }
        /// <summary>
        /// 伪合并文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        virtual public TranslatedFile Combine(TranslatedFile file)
        {
            Log.Information("检测到不支持合并的文件。取消合并");
            return this;
        }
    }
    class LangFile : TranslatedFile
    {
        public bool deserialized = false; // 非必要不解析，免得残废的lang解析炸掉
        public Dictionary<string, string> deserializedContent;

        // 继承构造函数
        public LangFile(Stream stream, FileCategory category, Config config)
            : base(stream, category, config)
        {
            deserializedContent = null;
        }
        // 从kv对顺便构造字符串内容备用
        public LangFile(FileCategory category, Dictionary<string, string> content)
            : base(category, content.SerializeAsset(category))
        {
            deserializedContent = content;
        }

        public void Deserialize()
        {
            if (!deserialized)
            {
                deserialized = true;
                deserializedContent = stringifiedContent.DeserializeAsset(category);
            }
        }
        /// <summary>
        /// 真合并文件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public override LangFile Combine(TranslatedFile file)
        {
            var castedFile = (LangFile)file;
            if ((castedFile is null) || castedFile.category != this.category)
            {
                Log.Information("检测到不支持合并的文件。取消合并");
                return this;
            }
            this.Deserialize();
            castedFile.Deserialize();
            var resultMap = new Dictionary<string, string>(deserializedContent);
            foreach (var pair in castedFile.deserializedContent)
            {
                if (!resultMap.TryAdd(pair.Key, pair.Value))
                {
                    Log.Warning("检测到相同 key 的条目：{0} -> {1} | {2}，选取 {1}",
                        pair.Key, resultMap[pair.Key], pair.Value);
                }
            }
            return new LangFile(category, resultMap)
            {
                relativePath = this.relativePath
            };
        }
    }
}
