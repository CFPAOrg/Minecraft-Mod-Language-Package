using System;
using System.IO;

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
            var lineHead = true;
            while (!_reader.EndOfStream) {
                if (Peek() == '=') {
                    SkipLine();
                    continue;
                }

                // 处理一行
                var shouldBreak = false;
                int c;
                while (!shouldBreak && (c = Consume()) != EOF) {
                    switch (c) {
                        case '/':
                            if (lineHead) {
                                switch (Peek()) {
                                    case '/':
                                        Consume();
                                        Write('#');
                                        break;
                                    case '*':
                                        Consume();
                                        Write('#');

                                        // 这里进入多行注释
                                        var shouldBreak2 = false;
                                        while (!shouldBreak2) {
                                            var tmp1 = Consume();
                                            switch (tmp1) {
                                                case '*':
                                                    var tmp2 = Peek();
                                                    CheckEOF(tmp2);
                                                    if (tmp2 == '/') {
                                                        Consume();
                                                        shouldBreak2 = true;
                                                    }

                                                    break;
                                                case '\r':
                                                case '\n':
                                                    CopyLineBreak(tmp1);
                                                    Write('#');
                                                    break;
                                                default:
                                                    CheckEOF(tmp1);
                                                    Write(tmp1);
                                                    break;
                                            }
                                        }

                                        break;
                                    default:
                                        Write('/');
                                        break;
                                }
                            }
                            else {
                                Write('/');
                            }

                            lineHead = false;
                            break;
                        case '\r':
                        case '\n':
                            CopyLineBreak(c);
                            lineHead = true;
                            shouldBreak = true;
                            continue;
                        case EOF:
                            shouldBreak = true;
                            continue;
                        default:
                            Write(c);
                            lineHead = false;
                            continue;
                    }
                }
            }

            void CopyLineBreak(int initChar) {
                switch (initChar) {
                    case '\r':
                        Write('\r');
                        if (Consume() != '\n') throw new FormatterException("无效换行符");
                        Write('\n');
                        break;
                    case '\n':
                        Write('\n');
                        break;
                    default:
                        throw new FormatterException("调用方未检查换行符");
                }
            }

            _writer.Close();
            _writer.Dispose();
        }

        // ReSharper disable once InconsistentNaming
        static void CheckEOF(int c) {
            if (c == EOF)
                throw new FormatterException("意外地遇到文件尾");
        }

        void SkipLine() {
            while (true) {
                var c = Consume();
                if (c == '\r') {
                    Consume(); // \r\n
                    break;
                }

                if (c == '\n' || c == EOF) {
                    break;
                }
            }
        }

        int Peek() => _reader.Peek();

        int Consume() => _reader.Read();

        void Write(char c) => _writer.Write(c);

        void Write(int c) => Write((char)c);


        [Serializable]
        public class FormatterException : Exception {
            public FormatterException(string message) : base(message) {
            }
        }
    }

}
