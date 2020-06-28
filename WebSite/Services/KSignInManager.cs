using Framework.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSite.Services
{
    public class KSignInManager : SignInManager<KUser>
    {
        public KSignInManager(UserManager<KUser> userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<KUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<KUser>> logger, IAuthenticationSchemeProvider schemes, IUserConfirmation<KUser> confirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
        }
    }
}
