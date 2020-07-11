using DataAccess.Layouts;
using Framework.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Readers.Delimited
{
    public class DelimitedReader : ReaderBase
    {
        private MetaBase Layout;
        public DelimitedLine Header { get; private set; }
        private bool HeaderRead = false;
        private DelimitedReaderOptions Options;
        private DelimitedLineReader DelimitedLineReader;
        public DelimitedReader(DelimitedReaderOptions options)
        {
            Options = options;
            DelimitedLineReader = new DelimitedLineReader(CreateTextReader());
        }

        public DelimitedReader(DelimitedReaderOptions options, MetaBase layout) : this(options)
        {
            Layout = layout;
        }

        private TextReader CreateTextReader()
        {
            var stream = new FileStream(Options.FilePath, FileMode.Open);
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

        public override IEnumerable<Record> Read()
        {
            if (HeaderRead == false) ReadHeader();
            do
            {
                DelimitedLineReader.ReadNext();
                var line = DelimitedLineReader.Next;
                Interlocked.Increment(ref RecordsReadCount);
                yield return ReadToLayout(line);

            } while (DelimitedLineReader.EOF == false && LimitReached() == false);
        }


        private bool LimitReached()
        {
            return Options.RecordsToRead >= 0 && RecordsReadCount >= Options.RecordsToRead;
        }

        public override void Dispose()
        {
            DelimitedLineReader.Dispose();
        }
    }

    public class DelimitedReaderOptions
    {
        public string FilePath { get; set; }
        public long RecordsToRead { get; set; } = -1;
    }
}