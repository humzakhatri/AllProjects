using Framework.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Services
{
    public class KRoleManager : RoleManager<KRole>
    {
        public KRoleManager(IRoleStore<KRole> store, IEnumerable<IRoleValidator<KRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<KRole>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
