using System;
using System.Collections.Generic;
using System.Text;

namespace Runtime.REST
{
    internal static class RestSubscriberFactory
    {
        internal static RestSubscriberBase Create(SubscriberTypes subscriberType)
        {
            switch (subscriberType)
            {
                case SubscriberTypes.File:
                    return new RestSubscriberFile();
                default:
                    throw new Exception("Cannot create the specified subscriber type.");
            }
        }
    }

    public enum SubscriberTypes
    {
        File
    }
}
