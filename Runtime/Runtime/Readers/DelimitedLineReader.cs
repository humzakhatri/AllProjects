using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Runtime.Runtime.Readers
{
    public class DelimitedLineReader : IDisposable
    {
        private CharReader CharReader;
        private bool InQoutes = false;
        public bool HasQoutes { get; set; } = true;
        private bool IgnoreDelimiter => InQoutes && HasQoutes;
        public DelimitedLine Next { get; private set; } = null;
        public char LineDelimiter { get; set; } = '\r';
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
                if (HasQoutes && CharReader.Next == '"')
                    InQoutes = !InQoutes;
                if (CharReader.Next == FieldDelimiter && !IgnoreDelimiter)
                {
                    line.Data.Add(sb.ToString());
                    sb.Clear();
                }
                if (isEnd)
                {
                    line.Data.Add(sb.ToString());
                    sb.Clear();
                    Next = line;
                    EOF = CharReader.EOF;
                    break;
                }
                if (CharReader.Next != FieldDelimiter || InQoutes)
                    sb.Append(CharReader.Next);
                RecordLength++;
            }
            while (true);
            while (CharReader.Peek == '\n' || CharReader.Peek == ' ' || CharReader.Peek == '\r' || CharReader.Peek == -1)
                CharReader.ReadNext();
            EOF = CharReader.EOF || CharReader.Peek == '\uffff';
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
