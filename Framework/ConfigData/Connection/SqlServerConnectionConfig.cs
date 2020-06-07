using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Framework.Database;

namespace Framework.ConfigData.Connection
{
    public class SqlServerConnectionConfig : DbConnectionConfigBase
    {
        public override DbProviderType DbProviderType => DbProviderType.SqlServer;

        public override string BuildConnectionString()
        {
            return $"Data Source={ServerName};Initial Catalog={DatabaseName};User ID={Credentials.Username};Password={Credentials.Password}";
        }
    }
}
