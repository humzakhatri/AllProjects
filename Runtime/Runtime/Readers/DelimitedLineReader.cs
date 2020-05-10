using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Runtime.Runtime.Readers
{
    public class DelimitedLineReader : IDisposable
    {
        private CharReader CharReader;
        public DelimitedLine Next { get; private set; } = null;
        public char LineDelimiter { get; set; } = '\n';
        public char FieldDelimiter { get; set; } = ',';
        public long RecordLength { get; private set; }
        public bool EOF { get; private set; } = false;
        public DelimitedLineReader(TextReader reader)
        {
            CharReader = new CharReader(reader);
        }

        public void ReadNext()
        {
            StringBuilder sb = new StringBuilder();
            var line = new DelimitedLine(FieldDelimiter);
            do
            {
                CharReader.ReadNext();
                bool isEnd = CharReader.EOF || CharReader.Next == LineDelimiter;
                if (CharReader.Next == FieldDelimiter || isEnd)
                {
                    line.Data.Add(sb.ToString());
                    sb.Clear();
                }
                if (isEnd)
                {
                    Next = line;
                    EOF = CharReader.EOF;
                    break;
                }

                sb.Append(CharReader.Next);
                RecordLength++;
            }
            while (true);
        }

        public void Dispose()
        {
            CharReader.Dispose();
        }
    }

    public class DelimitedLine
    {
        public readonly char Delimiter;
        public char Seperator;
        public List<string> Data { get; private set; } = new List<string>();
        public DelimitedLine(char delimiter)
        {
            Delimiter = delimiter;
        }
    }
}
