using Framework.ConfigData.Connection;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.ConfigData
{
    public abstract class DestinationDbConfigData : DestinationConfigDataBase, IHasTableConfig
    {
        public bool CreateTable { get; set; }
        public abstract DbConnectionConfigBase ConnectionConfig { get; set; }
        public DbTableConfig TableConfig { get; set; }
    }
}
