using DataAccess.Layouts;
using Framework.Common;
using Framework.ConfigData;
using Framework.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DataAccess.Helpers
{
    internal class SqlQueryBuilder
    {
        public string GetRepresentation(object value)
        {
            if (value?.GetType() == typeof(string))
                return $"'{value}'";
            else if (value?.GetType() == typeof(bool))
                return (bool)value ? "1" : "0";
            else if (value?.GetType() == typeof(long) ||
                value?.GetType() == typeof(int) ||
                value?.GetType() == typeof(float))
                return value.ToString();
            return $"NULL";
        }

        public IDbCommand GetQuery(DbSourceConfigBase config)
        {
            return GetQuery(config.TableConfig.TableName);
        }

        public IDbCommand GetQuery(DbSourceConfigBase config, string fieldName, object queryValue)
        {
            return GetSelectCommand(config.TableConfig.TableName, fieldName, queryValue);
        }

        public IDbCommand GetQuery(string tableName)
        {
            var query = $"SELECT * FROM {tableName}";
            IDbCommand command = new SqlCommand() { CommandText = query };
            return command;

        }

        public IDbCommand GetSelectCommand(string tableName, string fieldName, object queryValue)
        {
            var query = $@"SELECT * FROM {tableName} WHERE {tableName}.{fieldName} = @{nameof(fieldName)}";
            var command = new SqlCommand();
            command.CommandText = query;
            command.Parameters.Add(new SqlParameter(nameof(fieldName), queryValue));
            return command;
        }

        public string BuildInsertQuery(Record record, IHasTableConfig config) =>
            $"INSERT INTO [{config.TableConfig.TableName}] ({GetFieldNamesString(false, config)}) VALUES ({GetValuesString(record)})";

        private string GetValuesString(Record record) => record.Select(r => $"'{r.Value}'").ToDelimited(", ");

        private string GetFieldNamesString(bool IncludeTypeDefinition, IHasLayout config) =>
            config.Layout.Elements.Select(e => IncludeTypeDefinition ? $"[{e.Name}] NTEXT" : $"[{e.Name}]").ToDelimited(", ");

        public string GetCreateTableQuery(IHasTableConfig config)
        {
            return $"CREATE TABLE [{config.TableConfig.TableName}] ( {GetFieldNamesString(true, config)} )";
        }
    }
}
