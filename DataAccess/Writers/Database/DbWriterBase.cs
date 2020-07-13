using DataAccess.DbProviders;
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
            var query = BuildInsertQuery(record);
            using (var connection = new SqlConnection(Config.ConnectionConfig.BuildConnectionString()))
            {
                connection.Open();
                Provider.RunNonQuery(query, connection);
            }
        }

        public void CreateTable()
        {
            //TODO: handle creating the correct  datatype here
            var query = $"CREATE TABLE [{Config.TableConfig.TableName}] ( {GetFieldNamesString(true)} )";
            using (var connection = new SqlConnection(Config.ConnectionConfig.BuildConnectionString()))
            {
                connection.Open();
                Provider.RunNonQuery(query, connection);
            }
        }

        private string BuildInsertQuery(Record record) =>
            $"INSERT INTO [{Config.TableConfig.TableName}] ({GetFieldNamesString(false)}) VALUES ({GetValuesString(record)})";

        private string GetFieldNamesString(bool IncludeTypeDefinition) =>
            Config.Layout.Elements.Select(e => IncludeTypeDefinition ? $"[{e.Name}] NTEXT" : $"[{e.Name}]").ToDelimited(", ");

        private string GetValuesString(Record record) => record.Select(r => $"'{r.Value}'").ToDelimited(", ");
    }
}
