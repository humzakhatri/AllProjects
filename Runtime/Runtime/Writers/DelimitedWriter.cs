using Framework.Interfaces;
using Runtime.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Runtime.Runtime.Writers
{
    internal class DelimitedWriter : IFileWriter
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IncludeHeader { get; set; } = true;
        private TextWriter Writer;
        public char FieldDelimiter { get; set; } = ',';
        public DelimitedWriter(Stream stream)
        {
            Writer = new StreamWriter(stream);
        }

        public void Write(IDataObject dataObject)
        {
            if (!(dataObject is DataFieldCollection obj)) throw new Exception("DataObject is null or has incompatible type.");
            if (IncludeHeader)
                WriteHeader(obj);
            foreach (var record in obj.Records)
                Write(record);
        }

        private void WriteHeader(DataFieldCollection obj)
        {
            if (obj == null) throw new Exception("DataObject is null");
            var sb = new StringBuilder();
            bool first = true;
            foreach (var field in obj.Records[0])
            {
                if (!first)
                    sb.Append(FieldDelimiter);
                sb.Append(field.Name);
                first = false;
            }
            Writer.WriteLine(sb.ToString());
        }

        public void Write(Record record)
        {
            if (record == null) throw new Exception("Record is null");
            var sb = new StringBuilder();
            bool first = true;
            foreach (var item in record)
            {
                if (!first)
                    sb.Append(FieldDelimiter);
                sb.Append(item);
                first = false;
            }
            Writer.WriteLine(sb.ToString());
        }

        public void Dispose()
        {
            Writer.Dispose();
        }
    }
}
