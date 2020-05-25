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
    internal class DelimitedWriter : WriterBase
    {
        public bool IncludeHeader { get; set; } = true;
        private readonly TextWriter Writer;
        private readonly FileStream FileStream;
        public char FieldDelimiter { get; set; } = ',';
        public DelimitedWriter(string filePath)
        {
            FileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            Writer = new StreamWriter(FileStream);
        }

        public override void Write(IDataObject dataObject)
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

        public override void Write(Record record)
        {
            if (record == null) throw new Exception("Record is null");
            var sb = new StringBuilder();
            bool first = true;
            foreach (var item in record)
            {
                if (!first)
                    sb.Append(FieldDelimiter);
                sb.Append(item.Value);
                first = false;
            }
            Writer.WriteLine(sb.ToString());
        }

        public override void Dispose()
        {
            Writer.Flush();
            Writer.Dispose();
        }
    }
}
