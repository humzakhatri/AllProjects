using Framework.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.ConfigData.Connection
{
    public abstract class DbConnectionConfigBase
    {
        public abstract DbProviderType DbProviderType { get; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public Credentials Credentials { get; set; }
        protected string _ConnectionString;
        public abstract string BuildConnectionString();
    }
}
