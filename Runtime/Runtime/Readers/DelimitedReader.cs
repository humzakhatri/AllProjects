using Runtime.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Runtime.Runtime.Readers
{
    internal class DelimitedReader : ReaderBase
    {
        public DelimitedLine Header { get; private set; }
        public List<DelimitedLine> Data { get; private set; } = new List<DelimitedLine>();
        private bool HeaderRead = false;
        private string FilePath;
        private DelimitedLineReader DelimitedLineReader;
        public DelimitedReader(string filePath)
        {
            FilePath = filePath;
            DelimitedLineReader = new DelimitedLineReader(CreateTextReader());
        }

        private TextReader CreateTextReader()
        {
            var stream = new FileStream(FilePath, FileMode.Open);
            var reader = new StreamReader(stream);
            return reader;
        }

        public void ReadHeader()
        {
            DelimitedLineReader.ReadNext();
            Header = DelimitedLineReader.Next;
            HeaderRead = true;
        }

        public override void Read()
        {
            if (HeaderRead == false) ReadHeader();
            do
            {
                DelimitedLineReader.ReadNext();
                if (DelimitedLineReader.EOF) break;
                Data.Add(DelimitedLineReader.Next);

            } while (true);
        }

        public override void Dispose()
        {
            DelimitedLineReader.Dispose();
        }
    }
}