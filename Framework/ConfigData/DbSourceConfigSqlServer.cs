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

        public override SourceConfigType SourceConfigType => SourceConfigType.SqlServer;

        public override string GetQuery()
        {
            return $"Select * from {TableConfig.TableName}";//TODO: generate this query with DOM.
        }
    }
}
