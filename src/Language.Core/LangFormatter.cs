using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Language.Core {

    /*
     * MIT LICENSE
     *
     * Copyright 2021 Cyl18 
     * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
     * The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
     * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
     */
    public sealed class LangFormatter {
        readonly StreamReader _reader;
        readonly StreamWriter _writer;
        // ReSharper disable once InconsistentNaming
        const int EOF = -1;

        /// <summary>
        /// 初始化格式化器类，需要提供两个参数：reader和writer
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="writer"></param>
        public LangFormatter(StreamReader reader, StreamWriter writer) {
            _reader = reader;
            _writer = writer;
        }

        /// <summary>
        /// 格式化语言文件
        /// </summary>
        public void Format() {
            var lines = new List<string>();
            while (!_reader.EndOfStream) {
                lines.Add(_reader.ReadLine());
            }

            _reader.BaseStream.Seek(0, SeekOrigin.Begin);
            int c;
            var lineStart = true;
            var multiLineComment = false;
            while ((c = Consume()) != EOF) {
                if (lineStart) {
                    switch (c) {
                        case '/':
                            switch (Peek()) {
                                // '//' 的实现仅支持行首出现 在 enderio 的语言文件有 YouTube 链接 会导致问题
                                // 当然也可以手动设置开关
                                case '/':
                                    Consume();
                                    Write('#');
                                    continue;
                                // '/**/' 的实现假定 '/*' 仅仅在行首出现 '*/' 仅在行末出现
                                case '*':
                                    Consume();
                                    multiLineComment = true;
                                    continue;
                            }
                            break;
                        case '=':
                            SkipLine();
                            continue;
                    }

                    if (multiLineComment) Write('#');
                }

                if (multiLineComment && c == '*' && Peek() == '/') {
                    Consume();
                    multiLineComment = false;
                    continue;
                }
                lineStart = c == '\n';
                Write(c);
            }

            _reader.BaseStream.Seek(0, SeekOrigin.Begin);
            lines.Clear();
            while (!_reader.EndOfStream) {
                lines.Add(_reader.ReadLine());
            }

            _writer.BaseStream.Seek(0, SeekOrigin.Begin);
            if (!lines.Contains("#PARSE_ESCAPES")) {
                var result = from line in lines
                             where line.Contains("=") || line.StartsWith("#") || string.IsNullOrWhiteSpace(line) || string.IsNullOrEmpty(line)
                             select line;

                foreach (var s in result) {
                    _writer.WriteLineAsync(s);
                }
            }

            _reader.Close();
            _reader.Dispose();
            _writer.Close();
            _writer.Dispose();
        }
        void SkipLine() {
            int c;
            while ((c = Consume()) != '\n' && c != EOF) { }
        }

        int Peek() => _reader.Peek();
        int Consume() => _reader.Read();
        void Write(char c) => _writer.Write(c);
        void Write(int c) => Write((char)c);
    }
}
