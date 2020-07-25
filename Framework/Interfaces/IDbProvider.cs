using Framework.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Framework.Interfaces
{
    public interface IDbProvider
    {
        IEnumerable<object[]> QueryData(string queryText, IDbConnection connection);
        void RunNonQuery(string queryText, IDbConnection connection);
        MetaFlatObject BuildLayout(string tableName, IDbConnection connection);
        IDbConnection CreateConnection(string connectionString);
    }
}
