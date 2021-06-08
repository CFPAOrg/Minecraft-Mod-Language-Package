using System;
using System.Collections.Generic;
using System.IO;

using Packer.Extensions;
using Serilog;

namespace Packer.Models
{
    [Flags]
    public enum FileCategory
    {
        None = 0,         // 仅用于初始化为默认态
        JsonAlike = 1,    // 类 .json，标识需要转义与 json 式序列化
        LangAlike = 2,    // 类 .lang，标识无需转义与 lang 式序列化
        LanguageFile = 4, // 位于 /lang/ 中的文件，进行合并等
        OtherFiles = 8,   // 位于其余位置的文件，不进行合并
        JsonTranslationFormat = JsonAlike | LanguageFile, // */lang/*.json
        LangTranslationFormat = LangAlike | LanguageFile, // */lang/*.lang
        JsonOthers = JsonAlike | OtherFiles,              // */<not-lang>/*.json
        LangOthers = LangAlike | OtherFiles               // */<not-lang>/*.lang
    }
    public class TranslatedFile
    {
        public string relativePath;
        public readonly string stringifiedContent;
        public FileCategory category;

        public TranslatedFile(Stream stream, FileCategory category, Config config)
        { // 注：文件流在此处被关闭
            using var reader = new StreamReader(stream);
            stringifiedContent = reader.ReadToEnd().Preprocess(category, config);
            this.category = category;
        }
        public TranslatedFile(FileCategory category, string content)
        {
            this.category = category;
            stringifiedContent = content;
        }
        virtual public TranslatedFile Combine(TranslatedFile file)
        {
            Log.Information("检测到不支持合并的文件。取消合并");
            return this;
        }
    }
    class LangFile : TranslatedFile
    {
        public bool deserialized = false;
        public Dictionary<string, string> deserializedContent;

        public LangFile(Stream stream, FileCategory category, Config config) : base(stream, category, config)
        {
            deserializedContent = null;
        }
        public LangFile(FileCategory category, Dictionary<string, string> content) : base(category,
                                                                                          content.SerializeAsset(category))
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
