using Framework.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Runtime.Database
{
    internal class SqlServer
    {
        public void Execute(DbConnectInfoBase dbConnectInfo, string sqlStatement)
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

        public List<Object[]> ExecuteSelect(DbConnectInfoBase dbConnectInfo, string sqlStatement)
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
    }
}
