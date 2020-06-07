using Framework.ConfigData.Connection;
using Framework.Database;
using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Framework.ConfigData
{
    public abstract class DbSourceConfigBase : SourceConfigDataBase
    {
        public abstract string GetQuery();
        public abstract DbConnectionConfigBase ConnectionConfig { get; set; }
        public override SourceConfigType SourceConfigType => SourceConfigType.Database;
    }
}
