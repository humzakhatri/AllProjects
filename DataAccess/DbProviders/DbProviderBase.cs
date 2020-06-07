using Framework.ConfigData.Connection;
using Framework.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Database
{
    public abstract class DbProviderBase
    {
        public abstract IEnumerable<object[]> QueryData(string queryText, IDbConnection connection);
        public abstract void RunNonQuery(string queryText, IDbConnection connection);
        public abstract MetaFlatObject BuildLayout(string tableName, IDbConnection connection);
    }
}
