using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.ConfigData
{
    public class DelimitedSourceConfigData : SourceFileConfigData
    {
        public char FieldDelimiter { get; set; } = ',';
        public char LineDelimiter { get; set; } = '\n';
    }
}
