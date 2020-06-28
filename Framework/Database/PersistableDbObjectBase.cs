using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Database
{
    public class PersistableDbObjectBase : IDbPersistable
    {
        public long Id { get; set; }
    }
}
