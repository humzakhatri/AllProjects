using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Framework.ConfigData.Connection
{
    public class SqlServerConnectionConfig : DbConnectionConfigBase
    {
        protected override string BuildConnectionString()
        {
            return $"Data Source={ServerName};Initial Catalog={DatabaseName};User ID={Credentials.Username};Password={Credentials.Password}";
        }
    }
}
