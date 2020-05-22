using Framework.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Interfaces
{
    public abstract class SourceConfigDataBase : ISourceConfigData
    {
        public abstract SourceConfigType SourceConfigType { get; }

        public ITargetConfigData Next { get; set; }

        public ConfigType ConfigType => ConfigType.Source;

        public MetaBase Layout { get; set; }
    }
}
