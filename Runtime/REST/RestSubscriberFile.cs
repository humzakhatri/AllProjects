using Framework.REST.EndPoint;
using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.REST
{
    internal class RestSubscriberFile : RestSubscriberBase
    {
        public RestSubscriberFile()
        {

        }
        public override string ProcessRequest(RestRequestContext context)
        {
            return base.ProcessRequest(context); //TODO: this class needs to use the IFileReader to get data and return 
        }

        protected override void OnInitialize()
        {
            //TODO: Here you open the file
        }

        protected override void OnStart()
        {
            //TODO: Here you probably need to read the file
        }
    }
}
