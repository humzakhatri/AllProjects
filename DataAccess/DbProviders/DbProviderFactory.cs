using DataAccess.Database;
using Framework.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DbProviders
{
    public static class DbProviderFactory
    {
        public static DbProviderBase Create(DbProviderType dbProviderType)
        {
            switch (dbProviderType)
            {
                case DbProviderType.SqlServer:
                    return new DbProviderSqlServer();
                default:
                    throw new Exception("Db Provider not available for the given type.");
            }
        }
    }
}
