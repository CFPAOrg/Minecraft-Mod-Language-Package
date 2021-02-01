#nullable enable
using System;
using System.IO;
using System.Text;

namespace Language.Core {
    public class LangReader {
        private FileStream FileStream { get; set; }
        public StreamReader StreamReader { get;private set; }

        public LangReader(FileStream fileStream) {
            FileStream = fileStream;
            StreamReader = new StreamReader(FileStream);
        }

        public int Peek() {
            return StreamReader.Peek();
        }

        public int Read() {
            return StreamReader.Read();
        }

        public string? ReadLine() {
            return StreamReader.ReadLine();
        }

        public void Seek() {
            FileStream.Seek(-1, SeekOrigin.Current);
            StreamReader.DiscardBufferedData();
        }

        public void SeekToPreviousLineEnd() {
            if ((char)Peek() == '\n') {
                Read();
                return;
            }
            Seek();
            SeekToPreviousLineEnd();
        }
    }
}