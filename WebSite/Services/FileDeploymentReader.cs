using DataAccess.Transformers;
using Framework.Global;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using DataAccess.Layouts;
using DataAccess.Readers.Database;
using DataAccess.DbProviders;
using Framework.ConfigData;
using Framework.Website;
using Runtime.Persisters;
using Framework.Authentication;

namespace WebSite.Services
{
    public class FileDeploymentReader
    {
        public string GetResponse(string deploymentName)
        {
            using (var connection = KAppContext.CreateAndOpenRepositoryConnection())
            {
                var data = Read(connection, deploymentName);
                var json = JsonSerializer.Serialize(data);
                return json;
            }
        }

        public string GetResponse(string deploymentName, object keyValue)
        {
            using (var connection = KAppContext.CreateAndOpenRepositoryConnection())
            {
                var data = Read(connection, deploymentName, keyValue);
                var json = JsonSerializer.Serialize(data);
                return json;
            }
        }

        private IEnumerable<Record> Read(IDbConnection connection, string tableName)
        {
            var reader = GetReader(connection, tableName);
            return reader.Read();
        }

        private Record Read(IDbConnection connection, string tableName, object id)
        {
            var reader = GetReader(connection, tableName);
            var deployment = GetDeployment(tableName);
            return reader.Read(deployment.KeyFieldName, id);
        }

        private DbReaderBase GetReader(IDbConnection connection, string tableName)
        {
            var provider = DbProviderFactory.Create(KAppContext.RepositoryDbProviderType);
            var layout = provider.BuildLayout(tableName, connection);
            var tableConfig = new DbTableConfig() { TableName = tableName };
            var config = new DbSourceConfigSqlServer() { ConnectionConfig = KAppContext.GetRepositoryConnectionConfig(), TableConfig = tableConfig };
            return new DbReaderBase(config, layout);
        }

        private DataApiDeployment GetDeployment(string deploymentName)
        {
            var persister = new DataApiDeploymentPersister();
            return persister.GetWithPropertyValue(nameof(DataApiDeployment.Name), deploymentName);
        }
    }
}
