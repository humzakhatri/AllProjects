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
        public DelimitedLine Line { get; private set; }
        private Record Record;
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
            Record = new Record();
            for (int i = 0; i < Layout.Elements.Count; i++)
            {
                var dataField = new DataField();
                dataField.Meta = Layout.Elements[i];
                dataField.Value = Line.Data[i];
            }
        }

        public void ReadHeader()
        {
            DelimitedLineReader.ReadNext();
            Header = DelimitedLineReader.Next;
            HeaderRead = true;
        }

        public override IEnumerable<Record> Read()
        {
            if (HeaderRead == false) ReadHeader();
            do
            {
                DelimitedLineReader.ReadNext();
                if (DelimitedLineReader.EOF) break;
                Line = DelimitedLineReader.Next;
                ReadToLayout();
                yield return Record;

            } while (true);
        }

        public override void Dispose()
        {
            DelimitedLineReader.Dispose();
        }
    }
}