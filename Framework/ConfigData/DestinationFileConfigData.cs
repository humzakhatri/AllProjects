using Framework.Data;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.ConfigData
{
    public class DestinationFileConfigData : IFileConfigData
    {
        public string FilePath { get; set; }
        public MetaBase Layout { get; set; }
    }
}
