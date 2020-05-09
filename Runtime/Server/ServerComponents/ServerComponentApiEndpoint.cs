using Framework.REST.EndPoint;
using Microsoft.AspNetCore.Http;
using Runtime.Persisters;
using Runtime.REST;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Runtime.Server.ServerComponents
{
    internal class ServerComponentApiEndpoint : ServerComponentBase
    {
        private static string ConfigFilePath = @"C:\Data\Config.xml";
        private ApiTree ApiTree { get; set; } = new ApiTree();
        private ApiConfigurationPersister Persister;

        protected override void OnInitialize()
        {
            Persister = new ApiConfigurationPersister();
            LoadConfiguration();
        }

        protected override void OnStart()
        {
        }

        private void LoadConfiguration()
        {
            var apis = Persister.Load();
            LoadApisToTree(apis);
        }

        private void LoadApisToTree(IEnumerable<ApiConfiguration> apis)
        {
            apis.ToList().ForEach(a => ApiTree.Add(a.Path, a.Method, new RestSubscriberFile()));
        }

        public bool ProcessRequest(RestRequestContext context)
        {
            if (ApiTree.TryMatch(context.Url, context.Method, out var result) == false)
                return false;

            var subscriber = result as RestSubscriberBase;
            var response = subscriber.ProcessRequest(context);
            context.HttpContext.Response.WriteAsync(response);
            return true;
        }
    }
}
