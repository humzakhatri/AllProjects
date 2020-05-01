using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Database
{
    public abstract class DbConnectInfoBase
    {
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string SchemaName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
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
