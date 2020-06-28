using Framework.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Services
{
    public class KUserManager : UserManager<KUser>
    {
        public KUserManager(IUserStore<KUser> store, IOptions<IdentityOptions> optionsAccessor, IPasswordHasher<KUser> passwordHasher, IEnumerable<IUserValidator<KUser>> userValidators, IEnumerable<IPasswordValidator<KUser>> passwordValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<KUser>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }
    }
}
