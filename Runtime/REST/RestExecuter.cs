using Framework.REST;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HttpMethod = Framework.REST.HttpMethod;
using Localizable.Strings;

namespace Runtime.REST
{
    public class RestExecuter
    {
        public readonly RestConnection Connection;
        private HttpClient Client;
        private readonly HttpMethod _HttpMethod;
        public RestExecuter(RestConnection connection)
        {
            Connection = connection;
            _HttpMethod = connection.HttpMethod;
            Client = CreateClient();
        }
        public Task<HttpResponseMessage> Execute(RestRequest request)
        {
            switch (request.Method)
            {
                case HttpMethod.Get:
                    return Client.GetAsync(request.Path);
                case HttpMethod.Delete:
                    return Client.DeleteAsync(request.Path);
                case HttpMethod.Post:
                    return Client.PostAsync(request.Path, request.GetContent());
                case HttpMethod.Put:
                    return Client.PutAsync(request.Path, request.GetContent());
                default:
                    throw new Exception(Messages.MethodNotSupported.Text);
            }
        }

        private HttpClient CreateClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Connection.FullUrl);
            client.Timeout = new TimeSpan(0, 0, Connection.TimeoutInSeconds);
            return client;
        }
    }
}
