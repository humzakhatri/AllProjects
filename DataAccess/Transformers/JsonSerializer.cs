using DataAccess.Layouts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccess.Transformers
{
    public static class JsonSerializer
    {
        public static string Serialize(IEnumerable<Record> records)
        {
            var textWriter = new StringWriter();
            var writer = new JsonTextWriter(textWriter);
            writer.WriteStartArray();
            foreach (var record in records)
            {
                Serialize(writer, record);
            }
            writer.WriteEndArray();
            writer.Flush();
            return textWriter.ToString();
        }

        public static string Serialize(Record record)
        {
            var textWriter = new StringWriter();
            var writer = new JsonTextWriter(textWriter);
            Serialize(writer, record);
            return writer.ToString();
        }

        private static void Serialize(JsonTextWriter writer, Record record)
        {
            writer.WriteStartObject();
            foreach (var field in record)
            {
                writer.WritePropertyName(field.Name);
                writer.WriteValue(field.Value);
            }
            writer.WriteEndObject();
        }
    }
}