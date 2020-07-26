using DataAccess.Database;
using DataAccess.DbProviders;
using DataAccess.Layouts;
using Framework.ConfigData;
using Framework.Data;
using Microsoft.Data.SqlClient;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Helpers;

namespace DataAccess.Readers.Database
{
    public class DbReaderBase : ReaderBase
    {
        protected IDbProvider Provider;
        protected readonly MetaBase Layout;
        protected readonly DbSourceConfigBase Config;
        public DbReaderBase(DbSourceConfigBase config, MetaBase layout)
        {
            Layout = layout;
            Config = config;
            Provider = DbProviderFactory.Create(config.ConnectionConfig.DbProviderType);
        }
        public override IEnumerable<Record> Read()
        {
            IEnumerable<object[]> data;
            using (var connection = new SqlConnection(Config.ConnectionConfig.BuildConnectionString()))
            {
                connection.Open();
                data = Provider.QueryData(new SqlQueryBuilder().GetQuery(Config), connection);
                foreach (var item in data)
                    yield return ReadToLayout(item);
            }
        }

        public virtual Record Read(string fieldName, object valueToQuery)
        {
            object[] data;
            using (var connection = new SqlConnection(Config.ConnectionConfig.BuildConnectionString()))
            {
                connection.Open();
                data = Provider.QueryData(new SqlQueryBuilder().GetQuery(Config, fieldName, valueToQuery), connection).FirstOrDefault();
                return ReadToLayout(data);
            }
        }

        private Record ReadToLayout(object[] item)
        {
            if (Layout == null) throw new Exception("Layout not present.");
            var record = new Record();
            for (int i = 0; i < Layout.Elements.Count; i++)
            {
                var dataField = new DataField();
                dataField.Meta = Layout.Elements[i];
                dataField.Value = item[i].ToString();
                record.Add(dataField);
            }
            return record;
        }

        public override void Dispose()
        {

        }
    }
}
