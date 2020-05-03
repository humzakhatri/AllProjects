using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.REST
{
    internal class RestSubscriberFile : RestSubscriberBase
    {

        public override string ProcessRequest(string resolvedResource)
        {
            return resolvedResource; //TODO: this class needs to use the IFileReader to get data and return 
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
