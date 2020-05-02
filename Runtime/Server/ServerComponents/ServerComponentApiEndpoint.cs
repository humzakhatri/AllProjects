using Framework.REST.EndPoint;
using Runtime.REST;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Runtime.Server.ServerComponents
{
    internal class ServerComponentApiEndpoint : ServerComponentBase
    {
        private static string ConfigFilePath = @"C:\Data\Config.xml";
        private ApiTree ApiTree { get; set; } = new ApiTree();
        public ServerComponentApiEndpoint()
        {
        }

        protected override void OnInitialize()
        {
            LoadConfiguration();
        }

        protected override void OnStart()
        {
        }

        private void LoadConfiguration()
        {
            ApiConfigurationList apis;
            var serializer = new XmlSerializer(typeof(ApiConfigurationList));
            using (var reader = new StreamReader(ConfigFilePath))
                apis = (ApiConfigurationList)serializer.Deserialize(reader);
            LoadApisToTree(apis);
        }

        private void LoadApisToTree(ApiConfigurationList apis)
        {
            apis.ForEach(a => ApiTree.Add(a.Path, a.Method));
        }

        public void ProcessRequest(RestRequestContext context)
        {
        }
    }
}
