using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Framework.Database
{
    public class SqlServerConnectInfo : DbConnectInfoBase
    {
        protected override string BuildConnectionString()
        {
            return $"Data Source={ServerName};Initial Catalog={DatabaseName};User ID={UserName};Password={Password}";
        }
    }
}
