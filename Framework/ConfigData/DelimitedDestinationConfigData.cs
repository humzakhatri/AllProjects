using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.ConfigData
{
    public class DelimitedDestinationConfigData : DestinationFileConfigData
    {
        public char FieldDelimiter { get; set; } = ',';

        public override TargetConfigType TargetConfigType => TargetConfigType.Delimited;
    }
}
