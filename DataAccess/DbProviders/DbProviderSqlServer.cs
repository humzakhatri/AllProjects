using Framework.ConfigData.Connection;
using Framework.Data;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Data.Common;

namespace DataAccess.Database
{
    internal class DbProviderSqlServer : DbProviderBase
    {
        protected const int TableNameIndex = 3;
        public override void RunNonQuery(string queryText, IDbConnection connection)
        {
            try
            {
                using (var command = new SqlCommand(queryText, connection as SqlConnection))
                {
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void RunNonQuery(IDbCommand command, IDbConnection connection)
        {
            try
            {
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override IEnumerable<object[]> QueryData(string queryText, IDbConnection connection)
        {
            using (var command = new SqlCommand(queryText, (SqlConnection)connection))
            {
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                    while (dataReader.Read())
                    {
                        var row = new object[dataReader.FieldCount];
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            row[i] = dataReader.GetValue(i);
                        }
                        yield return row;
                    }
                dataReader.Close();
            }
        }

        public override IEnumerable<object[]> QueryData(IDbCommand command, IDbConnection connection)
        {
            command.Connection = connection;
            DbDataReader dataReader;
            dataReader = (DbDataReader)command.ExecuteReader();
            if (dataReader.HasRows)
                while (dataReader.Read())
                {
                    var row = new object[dataReader.FieldCount];
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        row[i] = dataReader.GetValue(i);
                    }
                    yield return row;
                }
            dataReader.Close();

        }

        public override MetaFlatObject BuildLayout(string tableName, IDbConnection connection)
        {
            var query = $"select * from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME='{tableName}'";//TODO: create this query with sql DOM.
            var result = QueryData(query, connection);
            var layout = new MetaFlatObject();
            foreach (var item in result)
            {
                var element = new MetaElement() { Name = item[TableNameIndex].ToString() };
                layout.Elements.Add(element);
            }
            return layout;
        }

        public override IDbConnection CreateConnection(string connectionString) => new SqlConnection() { ConnectionString = connectionString };
    }
}
