using Framework.Data;
using Runtime.Data;
using Runtime.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Runtime.Runtime.Readers
{
    internal class DelimitedReader : ReaderBase
    {
        private MetaBase Layout;
        public DelimitedLine Header { get; private set; }
        public List<DelimitedLine> Line { get; private set; } = new List<DelimitedLine>();
        private bool HeaderRead = false;
        private string FilePath;
        private DelimitedLineReader DelimitedLineReader;
        public DelimitedReader(string filePath)
        {
            FilePath = filePath;
            DelimitedLineReader = new DelimitedLineReader(CreateTextReader());
        }

        public DelimitedReader(string filePath, MetaBase layout) : this(filePath)
        {
            Layout = layout;
        }

        private TextReader CreateTextReader()
        {
            var stream = new FileStream(FilePath, FileMode.Open);
            var reader = new StreamReader(stream);
            return reader;
        }

        private void ReadToLayout()
        {
            if (Layout == null) throw new Exception("Layout not present.");
            var result = new DataFieldCollection();
            result.SetMeta(Layout);
            for (int i = 0; i < Line.Count; i++)
            {
                for (int j = 0; j < Header.Data.Count; j++)
                {
                    result.AddValue(i, Header.Data[j], Line[i].Data[j]);
                }
            }
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
                Line.Add(DelimitedLineReader.Next);

            } while (true);
            ReadToLayout();
        }

        public override void Dispose()
        {
            DelimitedLineReader.Dispose();
        }
    }
}