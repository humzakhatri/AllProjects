using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Persisters
{
    public abstract class PersisterBase<T> where T : class
    {
        public abstract T Load(long id);
        public abstract IEnumerable<T> Load();
        public abstract void Save(T obj);
        public abstract void Update(T obj);
    }
}
