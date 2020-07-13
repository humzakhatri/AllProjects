using Framework.ConfigData.Connection;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.ConfigData
{
    public class DbDestinationConfigSqlServer : DestinationDbConfigData
    {
        public override DbConnectionConfigBase ConnectionConfig { get; set; } = new SqlServerConnectionConfig();

        public override TargetConfigType TargetConfigType => TargetConfigType.SqlServer;
    }
}
