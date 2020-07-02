using Framework.Database;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Persister
{
    public static class PersistableObjectSchemaReader
    {
        public static void SetPropertyValues(Object obj, Object[] values)
        {
            var properties = obj.GetType().GetProperties();
            int i = 0;
            foreach (var property in properties)
            {
                property.SetValue(obj, values[i++]);
            }
        }
    }
}
