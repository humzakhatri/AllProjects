using Framework.Data;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.ConfigData
{
    public abstract class SourceFileConfigData : IFileConfigData
    {
        public string FilePath { get; set; }
        public MetaBase Layout { get; set; }
    }
}
