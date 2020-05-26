using Framework.ConfigData.Connection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Database
{
    public abstract class DbProviderBase : IDisposable
    {
        public abstract void Dispose();
    }
}
