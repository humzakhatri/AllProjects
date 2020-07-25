using Framework.ConfigData.Connection;
using Framework.Data;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Database
{
    public abstract class DbProviderBase : IDbProvider
    {
        public abstract IEnumerable<object[]> QueryData(string queryText, IDbConnection connection);
        public abstract void RunNonQuery(string queryText, IDbConnection connection);
        public abstract MetaFlatObject BuildLayout(string tableName, IDbConnection connection);
        public abstract IDbConnection CreateConnection(string connectionString);
    }
}
