using Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.Interfaces
{
    interface IRestSubscriber:IProcessor
    {
        string ProcessRequest(string resolvedResource);//TODO: this needs to get more specific
    }
}
