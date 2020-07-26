using Framework.Database;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Authentication
{
    public class DataApiDeployment : PersistableDbObjectBase, INamed
    {
        public long UserId { get; set; }
        [NVarChar(200)]
        public string Name { get; set; }
        [NVarChar(200)]
        public string DataTableName { get; set; }
        [NVarChar(100)]
        public Guid Identifier { get; set; }
        [NVarChar(150)]
        public string KeyFieldName { get; set; }
    }
}
