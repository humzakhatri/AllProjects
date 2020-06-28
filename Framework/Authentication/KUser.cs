using Framework.Database;
using Framework.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Authentication
{
    public class KUser : PersistableDbObjectBase
    {
        public KUser() { }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public long SubscriptionId { get; set; }
        public string PasswordHash { get; set; }
    }
}
