using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Runtime.Persisters;
using static Framework.REST.UrlTemplates;

namespace RestServer.Controllers
{
    public abstract class ObjectControllerBase<T, P> : Controller where T : class where P : PersisterBase<T>
    {
        private P Persister;
        public ObjectControllerBase(P persister)
        {
            Persister = persister;
        }

        public T GetApiConfiguration(long id)
        {
            return Persister.Load(id);
        }

        [HttpGet(TAll)]
        public IEnumerable<T> GetApiConfigurations()
        {
            return Persister.Load();
        }

        [HttpPost]
        public void PostApiConfiguration([FromBody]T apiConfiguration)
        {
            Persister.Save(apiConfiguration);
        }

        [HttpPut]
        public void PutApiConfiguration([FromBody] T apiConfiguration)
        {
            Persister.Update(apiConfiguration);
        }
    }
}