using Runtime.Interfaces;
using Runtime.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.REST
{
    internal abstract class RestSubscriberBase : RuntimeProcessorBase
    {
        public virtual string ProcessRequest(string resolvedResource)
        {
            return resolvedResource;
        }
    }
}
