using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Interfaces
{
    public interface ITargetConfigData : IConfigData, IHasLayout
    {
        public TargetConfigType TargetConfigType { get; }
    }

    public enum TargetConfigType
    {
        Delimited
    }
}
