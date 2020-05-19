using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Interfaces
{
    public interface IFileConfigData : IConfigData, IHasLayout
    {
        string FilePath { get; set; }
    }
}
