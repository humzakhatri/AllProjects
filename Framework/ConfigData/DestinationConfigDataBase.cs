using Framework.Data;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.ConfigData
{
    public abstract class DestinationConfigDataBase : ITargetConfigData
    {
        public abstract TargetConfigType TargetConfigType { get; }

        public ITargetConfigData Next { get; set; }

        public ConfigType ConfigType => ConfigType.Destination;

        public MetaBase Layout { get; set; }
    }
}
