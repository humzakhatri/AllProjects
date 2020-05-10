﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Runtime.Runtime.Readers
{
    public class DelimitedLineReader
    {
        private CharReader CharReader;
        public string Next { get; private set; } = null;
        public char LineDelimiter { get; set; } = '\n';
        public string Record { get; private set; } = null;
        public long RecordLength { get; private set; }
        public DelimitedLineReader(TextReader reader)
        {
            CharReader = new CharReader(reader);
        }

        public void ReadNext()
        {
            StringBuilder sb = new StringBuilder();
            do
            {
                CharReader.ReadNext();
                if (CharReader.EOF || CharReader.Next == LineDelimiter)
                {
                    Record = sb.ToString();
                    return;
                }
                sb.Append(CharReader.Next);
                RecordLength++;
            }
            while (true);
        }
    }
}