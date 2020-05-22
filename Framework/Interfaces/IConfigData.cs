using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Interfaces
{
    public interface IConfigData
    {
        ITargetConfigData Next { get; set; }
        ConfigType ConfigType { get; }
    }

    public enum ConfigType
    {
        Source,
        Transformation,
        Destination
    }
}
