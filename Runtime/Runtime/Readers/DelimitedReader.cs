using Framework.Data;
using Runtime.Data;
using Runtime.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Runtime.Runtime.Readers
{
    internal class DelimitedReader : ReaderBase
    {
        private MetaBase Layout;
        public DelimitedLine Header { get; private set; }
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

        private Record ReadToLayout(DelimitedLine line)
        {
            if (Layout == null) throw new Exception("Layout not present.");
            var record = new Record();
            for (int i = 0; i < Layout.Elements.Count; i++)
            {
                var dataField = new DataField();
                dataField.Meta = Layout.Elements[i];
                dataField.Value = line.Data[i];
                record.Add(dataField);
            }
            return record;
        }

        public void ReadHeader()
        {
            DelimitedLineReader.ReadNext();
            Header = DelimitedLineReader.Next;
            HeaderRead = true;
        }

        public override async IAsyncEnumerable<Record> Read()
        {
            if (HeaderRead == false) ReadHeader();
            do
            {
                yield return await Task.Run(() =>
                {
                    DelimitedLineReader.ReadNext();
                    var line = DelimitedLineReader.Next;
                    return ReadToLayout(line);
                });

            } while (DelimitedLineReader.EOF == false);
        }

        public override void Dispose()
        {
            DelimitedLineReader.Dispose();
        }
    }
}