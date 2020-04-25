using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Framework.REST
{
    public class HttpResponseParser
    {
        public async Task<string> Parse(HttpResponseMessage httpResponseMessage)
        {
            var content = httpResponseMessage.Content;
            return await content.ReadAsStringAsync();
        }
    }
}
