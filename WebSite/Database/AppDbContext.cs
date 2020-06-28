using Framework.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSite.Services;

namespace WebSite.Database
{
    public class KUserPersister
    {
        public List<KUser> MockerUsers { get; set; } = new List<KUser>();
    }
}
