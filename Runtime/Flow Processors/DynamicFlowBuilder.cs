using DataAccess.Layout.Builder;
using Framework.ConfigData;
using Framework.Document;
using Framework.Global;
using Framework.Website;
using Runtime.Runtime.Pipeline;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Runtime.Flow_Processors
{
    public class DynamicFlowBuilder
    {
        public DataflowDocument SaveDeployedFileToRepository(DeployedFileInfo info)
        {
            var dir = TempFileManager.TempDirectory;
            var fullPath = Path.Combine(dir, info.RelativePath);
            DelimitedLayoutBuilder builder = new DelimitedLayoutBuilder(new FileLayoutBuilderOptions() { FilePath = fullPath });

            builder.Build();

            var source = new DelimitedSourceConfigData() { FilePath = fullPath, Layout = builder.Layout };

            var tableConfig = new DbTableConfig() { TableName = info.DbTableName };

            var destination = new DbDestinationConfigSqlServer() { ConnectionConfig = KAppContext.GetRepositoryConnectionConfig(), Layout = builder.Layout, TableConfig = tableConfig, CreateTable = true };

            source.Next = destination;

            var document = new DataflowDocument() { Source = source };
            return document;
        }
    }
}
