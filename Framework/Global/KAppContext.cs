using Framework.ConfigData.Connection;
using Framework.Database;
using Framework.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Text;

namespace Framework.Global
{
    public static class KAppContext
    {
        static KAppContext()
        {
        }

        public static SqlConnection CreateAndOpenRepositoryConnection()
        {
            var cred = new Credentials() { Username = "sa", Password = "Astera123" };
            var connectionConfig = new SqlServerConnectionConfig() { Credentials = cred, DatabaseName = "testfaaran", ServerName = "ASTWKS246" };
            var conn = new SqlConnection() { ConnectionString = connectionConfig.BuildConnectionString() };
            conn.Open();
            return conn;
        }

        public static DbProviderType RepositoryDbProviderType => DbProviderType.SqlServer;
    }
}
