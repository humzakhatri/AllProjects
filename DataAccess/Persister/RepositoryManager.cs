using DataAccess.Database;
using DataAccess.DbProviders;
using Framework.Database;
using Framework.Global;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Persister
{
    public static class RepositoryManager
    {
        public static void CreateRepository()
        {
            var provider = DbProviderFactory.Create(DbProviderType.SqlServer);
            foreach (Type type in GetRepositoryTypes())
            {
                Type baseType = typeof(DbPersisterBase<>);
                Type persisterType = baseType.MakeGenericType(type);
                dynamic persister = Activator.CreateInstance(persisterType);
                string query = persister.GetCreationQuery();
                using var connection = KAppContext.CreateAndOpenRepositoryConnection();
                provider.RunNonQuery(query, connection);
            }
        }

        private static IEnumerable<Type> GetRepositoryTypes()
        {
            var domain = AppDomain.CurrentDomain;
            var assemblies = domain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.IsSubclassOf(typeof(PersistableDbObjectBase)))
                        yield return type;
                }
            }
        }
    }
}
