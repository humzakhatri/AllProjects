using Framework.Data;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.ConfigData
{
    public abstract class DestinationFileConfigData : DestinationConfigDataBase
    {
        public string FilePath { get; set; }
    }
}
