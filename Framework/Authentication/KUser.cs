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
        [NVarChar(50)]
        public string UserName { get; set; }
        [NVarChar(200)]
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public long SubscriptionId { get; set; }
        [NText]
        public string PasswordHash { get; set; }
    }
}
