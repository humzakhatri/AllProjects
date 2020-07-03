using DataAccess.Database;
using Framework.Common;
using Framework.Database;
using Framework.Global;
using Framework.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace DataAccess.Persister
{
    public class DbPersisterBase<T> where T : PersistableDbObjectBase
    {
        #region public 
        public T GetWithPropertyValue(string propertyName, object value)
        {
            var provider = new DbProviderSqlServer();
            IEnumerable<Object[]> result;
            string queryText = $"SELECT {GetPropertyNamesString(true)} FROM {typeof(T).Name} WHERE {propertyName} = {GetRepresentation(value)}";
            using (var connection = KAppContext.GetRepositoryConnection())
            {
                result = provider.QueryData(queryText, connection);
                var first = result.FirstOrDefault();
                var instance = (T)Activator.CreateInstance(typeof(T));
                if (first == null) return null;
                PersistableObjectSchemaReader.SetPropertyValues(instance, first);
                return instance;
            }
        }

        public void Save(T obj)
        {
            var provider = new DbProviderSqlServer();
            string queryText = $"INSERT INTO {typeof(T).Name} ({GetPropertyNamesString(false)}) VALUES ({GetPropertyValuesString(obj)})";
            using (var connection = KAppContext.GetRepositoryConnection())
            {
                provider.RunNonQuery(queryText, connection);
            }
        }

        public string GetCreationQuery()
        {
            return $"CREATE TABLE {typeof(T).Name} ({GetAllFieldsDefinition()})";
        }
        #endregion

        #region private
        private string GetPropertyNamesString(bool includeId)
        {
            var properties = typeof(T).GetProperties();
            StringBuilder builder = new StringBuilder();
            return properties.Where(s => (!IsId(s)) || includeId).Select(p => p.Name).ToDelimited(",");
        }

        private string GetPropertyValuesString(T obj)
        {
            var properties = obj.GetType().GetProperties();
            return properties.Where(s => !IsId(s)).Select(p => GetRepresentation(p.GetValue(obj))).ToDelimited(",");
        }

        private bool IsId(PropertyInfo propertyInfo)
        {
            var attributes = propertyInfo.GetCustomAttributes();
            return attributes.Any(a => a is IdentityAttribute);
        }

        private string GetRepresentation(object value)
        {
            if (value.GetType() == typeof(string))
                return $"'{value}'";
            else if (value.GetType() == typeof(bool))
                return (bool)value ? "1" : "0";
            return $"{value}";
        }
        private string GetAllFieldsDefinition()
        {
            var properties = typeof(T).GetProperties();
            return properties.Select(p => GetFieldDefinition(p)).ToDelimited(",");
        }
        private string GetFieldDefinition(PropertyInfo propertyInfo)
        {
            var attributes = propertyInfo.GetCustomAttributes();
            var dataTypeAttribute = attributes.FirstOrDefault(a => a is IDbFieldType) as IDbFieldType;
            if (dataTypeAttribute != null)
                return $"{propertyInfo.Name} {dataTypeAttribute.Datatype} {GetConstraints(propertyInfo)}";
            else
                return $"{propertyInfo.Name} {GetDataTypeForValueTypes(propertyInfo)} {GetConstraints(propertyInfo)}";
        }
        private string GetDataTypeForValueTypes(PropertyInfo propertyInfo)
        {
            if (propertyInfo.PropertyType == typeof(long))
                return "BIGINT";
            else if (propertyInfo.PropertyType == typeof(int))
                return "INT";
            else if (propertyInfo.PropertyType.IsEnum)
                return "INT";
            else if (propertyInfo.PropertyType == typeof(bool))
                return "BIT";
            throw new Exception($"Unsupported Type, Dev: please add an attribute to the field {propertyInfo.Name} or add one more condition here.");
        }
        private string GetConstraints(PropertyInfo propertyInfo)
        {
            var attributes = propertyInfo.GetCustomAttributes();
            var constraint = attributes.Where(a => a is IDbFieldConstraint).Cast<IDbFieldConstraint>().Select(c => c.Constraint);
            return constraint.ToDelimited(" ");
        }
        #endregion
    }
}
