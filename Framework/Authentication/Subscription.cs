using Framework.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Authentication
{
    public class Subscription : PersistableDbObjectBase
    {
        public SubscriptionType SubscriptionType { get; set; }
        //TODO add other details here to save for the subscription
    }

    public enum SubscriptionType
    {
        Free//TODO: Add more subscriptions types
    }
}
