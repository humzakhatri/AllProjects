using Framework.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Authentication
{
    public class Subscription : PersistableDbObjectBase
    {
        public SubscriptionType SubscriptionType { get; set; } = SubscriptionType.Free;
        [Decimal(10, 3)]
        public decimal MonthlyFee { get; set; }
        public int DataTableLimit { get; set; }
        public int PerTableRecordLimit { get; set; }
        //TODO add other details here to save for the subscription
    }

    public enum SubscriptionType
    {
        Free,//TODO: Add more subscriptions types
        Standard,
        Premium
    }

    public class SubscriptionBuilder
    {
        public Subscription GetFreeSubscription()
        {
            return new Subscription()
            {
                SubscriptionType = SubscriptionType.Free,
                MonthlyFee = 0
            };
        }
    }
}
