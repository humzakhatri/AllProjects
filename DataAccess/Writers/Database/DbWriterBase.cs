using DataAccess.DbProviders;
using DataAccess.Helpers;
using DataAccess.Layouts;
using DataAccess.Writer;
using Framework.Common;
using Framework.ConfigData;
using Framework.Data;
using Framework.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace DataAccess.Writers.Database
{
    public class DbWriterBase : WriterBase
    {
        protected IDbProvider Provider;
        protected readonly DestinationDbConfigData Config;
        public DbWriterBase(DestinationDbConfigData config)
        {
            Config = config;
            Provider = DbProviderFactory.Create(config.ConnectionConfig.DbProviderType);
        }
        public override void Write(IDataObject dataObject)
        {
            if (!(dataObject is DataFieldCollection obj)) throw new Exception("DataObject is null or has incompatible type.");
            foreach (var record in obj.Records)
                Write(record);
        }

        public override void Write(Record record)
        {
            if (record == null) throw new Exception("Record is null");
            var query = new SqlQueryBuilder().BuildInsertQuery(record, Config);
            using (var connection = new SqlConnection(Config.ConnectionConfig.BuildConnectionString()))
            {
                connection.Open();
                Provider.RunNonQuery(query, connection);
            }
        }

        public void CreateTable()
        {
            //TODO: handle creating the correct  datatype here
            var query = new SqlQueryBuilder().GetCreateTableQuery(Config);
            using (var connection = new SqlConnection(Config.ConnectionConfig.BuildConnectionString()))
            {
                connection.Open();
                Provider.RunNonQuery(query, connection);
            }
        }
    }
}
