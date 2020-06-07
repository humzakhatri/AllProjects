using Framework.ConfigData.Connection;
using Framework.Database;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.ConfigData
{
    public class DbSourceConfigSqlServer : DbSourceConfigBase
    {
        public override DbConnectionConfigBase ConnectionConfig { get; set; } = new SqlServerConnectionConfig();

        public override string GetQuery()
        {
            throw new NotImplementedException();
        }
    }
}
