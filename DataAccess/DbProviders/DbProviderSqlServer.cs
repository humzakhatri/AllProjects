using Framework.ConfigData.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccess.Database
{
    internal class DbProviderSqlServer : DbProviderBase
    {
        public void ExecuteNonQuery(DbConnectionConfigBase dbConnectInfo, string sqlStatement)
        {
            try
            {
                using (var connection = new SqlConnection(dbConnectInfo.ConnectionString))
                using (var command = new SqlCommand(sqlStatement, connection))
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

        public List<Object[]> GetData(DbConnectionConfigBase dbConnectInfo, string sqlStatement)
        {
            SqlDataReader dataReader;
            var data = new List<Object[]>();
            try
            {
                using (var connection = new SqlConnection(dbConnectInfo.ConnectionString))
                using (var command = new SqlCommand(sqlStatement, connection))
                {
                    connection.Open();
                    dataReader = command.ExecuteReader();
                    if (dataReader.HasRows)
                        while (dataReader.Read())
                        {
                            var row = new object[dataReader.FieldCount];
                            for (int i = 0; i < dataReader.FieldCount; i++)
                            {
                                row[i] = dataReader.GetValue(i);
                            }
                            data.Add(row);
                        }
                    dataReader.Close();
                    connection.Close();
                }
                return data;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
