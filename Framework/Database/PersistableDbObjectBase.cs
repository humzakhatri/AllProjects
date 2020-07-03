using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Database
{
    public class PersistableDbObjectBase : IDbPersistable
    {
        [Identity]
        [NotNull]
        public long Id { get; set; }
    }
}
