using Framework.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebSite.Database;

namespace WebSite.Services
{
    public class KUserStore : IUserStore<KUser>, IUserPasswordStore<KUser>, IUserEmailStore<KUser>, IQueryableUserStore<KUser>, IUserLockoutStore<KUser>
    {

        public IQueryable<KUser> Users => throw new NotImplementedException();
        private readonly KUserPersister UserPersister;
        public KUserStore(KUserPersister userPersister)
        {
            UserPersister = userPersister;
        }
        public Task<IdentityResult> CreateAsync(KUser user, CancellationToken cancellationToken)
        {
            return Task.Run(() => { UserPersister.MockerUsers.Add(user); return IdentityResult.Success; });
        }

        public Task<IdentityResult> DeleteAsync(KUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public Task<KUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return Task.Run(() => { return UserPersister.MockerUsers.FirstOrDefault(u => u.Email == normalizedEmail); });
        }

        public Task<KUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return Task.Run(() => { return UserPersister.MockerUsers.FirstOrDefault(u => u.Id == long.Parse(userId)); });
        }

        public Task<KUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return Task.Run(() => { return UserPersister.MockerUsers.FirstOrDefault(u => u.UserName.ToUpper() == normalizedUserName); });
        }

        public Task<string> GetEmailAsync(KUser user, CancellationToken cancellationToken)
        {
            return Task.Run(() => { return user.Email; });
        }

        public Task<bool> GetEmailConfirmedAsync(KUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public Task<string> GetNormalizedEmailAsync(KUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email.ToUpper());
        }

        public Task<string> GetNormalizedUserNameAsync(KUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName.ToUpper());
        }

        public Task<string> GetPasswordHashAsync(KUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<string> GetUserIdAsync(KUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(KUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public Task<bool> HasPasswordAsync(KUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(string.IsNullOrEmpty(user.PasswordHash) == false);
        }

        public Task SetEmailAsync(KUser user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            return Task.CompletedTask;
        }

        public Task SetEmailConfirmedAsync(KUser user, bool confirmed, CancellationToken cancellationToken)
        {
            user.EmailConfirmed = true;
            return Task.CompletedTask;
        }

        public Task SetNormalizedEmailAsync(KUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task SetNormalizedUserNameAsync(KUser user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task SetPasswordHashAsync(KUser user, string passwordHash, CancellationToken cancellationToken)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(KUser user, string userName, CancellationToken cancellationToken)
        {
            user.UserName = userName;
            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(KUser user, CancellationToken cancellationToken)
        {
            UserPersister.MockerUsers.RemoveAll(u => u.UserName == user.UserName);
            UserPersister.MockerUsers.Add(user);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<DateTimeOffset?> GetLockoutEndDateAsync(KUser user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(KUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task<int> IncrementAccessFailedCountAsync(KUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public Task ResetAccessFailedCountAsync(KUser user, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task<int> GetAccessFailedCountAsync(KUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(0);
        }

        public Task<bool> GetLockoutEnabledAsync(KUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(false);
        }

        public Task SetLockoutEnabledAsync(KUser user, bool enabled, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
