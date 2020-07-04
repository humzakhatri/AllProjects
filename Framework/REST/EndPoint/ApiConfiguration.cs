using Framework.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.REST.EndPoint
{
    public class ApiConfiguration : PersistableDbObjectBase
    {
        [XmlSerializableField]
        public List<string> QueryParameters { get; set; } = new List<string>();
        public HttpMethod Method { get; set; }
        [NVarChar(200)]
        public string Path { get; set; }
    }
}
