using Framework.ConfigData.Connection;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.ConfigData
{
    public class DatabaseSourceConfigSqlServer : DatabaseSourceConfigBase
    {
        public override SourceConfigType SourceConfigType => SourceConfigType.SqlServer;
        public SqlServerConnectionConfig ConnectionConfig { get; set; } = new SqlServerConnectionConfig();
    }
}
