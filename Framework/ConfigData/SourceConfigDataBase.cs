using Framework.Data;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.ConfigData
{
    public abstract class SourceConfigDataBase : ISourceConfigData
    {
        public abstract SourceConfigType SourceConfigType { get; }

        public ITargetConfigData Next { get; set; }

        public ConfigType ConfigType => ConfigType.Source;

        public MetaBase Layout { get; set; }
    }
}
