using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Framework.REST
{
    public class RestExecuter
    {
        public readonly RestConnection Connection;
        private HttpClient Client;
        public RestExecuter(RestConnection connection)
        {
            Connection = connection;
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
                default:
                    throw new Exception("Must provide content with Put Or Post.");
            }
        }

        public Task<HttpResponseMessage> Execute(RestRequest request, HttpContent content)
        {
            switch (request.Method)
            {
                case HttpMethod.Post:
                    return Client.PostAsync(request.Path, content);
                case HttpMethod.Put:
                    return Client.PutAsync(request.Path, content);
                default:
                    throw new Exception("Cannot add content to get or delete methods.");
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
