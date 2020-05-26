using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.ConfigData.Connection
{
    public abstract class DbConnectionConfigBase
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string SchemaName { get; set; }
        public Credentials Credentials { get; set; }
        protected string _ConnectionString;
        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_ConnectionString))
                    _ConnectionString = BuildConnectionString();
                return _ConnectionString;
            }
        }
        protected abstract string BuildConnectionString();
    }
}
