using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Interfaces
{
    public interface ISourceConfigData : IConfigData, IHasLayout
    {
        public SourceConfigType SourceConfigType { get; }
    }

    public enum SourceConfigType
    {
        Delimited,
        Database
    }
}
