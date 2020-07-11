using DataAccess.DbProviders;
using Framework.Global;
using Framework.Interfaces;
using Framework.Website;
using Microsoft.AspNetCore.Http;
using Runtime.REST;
using Runtime.Runtime;
using Runtime.Server.ServerComponents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Server
{
    public class RuntimeServer : IRuntimeServerProxy
    {
        public void ReplicateFileInDatabase(DeployedFileInfo fileInfo)
        {
            var provider = DbProviderFactory.Create(KAppContext.RepositoryDbProviderType);
            using var connection = KAppContext.CreateAndOpenRepositoryConnection();
        }
    }
}
