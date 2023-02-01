using Microsoft.EntityFrameworkCore;
using DP_SUM0023.Data.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DP_SUM0023.Data.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly CustomDbContext dbContext;

        public UserAccountService(CustomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<UserAccount> AuthenticateUser(string username, string password)
        {
            UserAccountLogin? accountLogin = await dbContext.AccountLogin.SingleOrDefaultAsync(x => x.Username == username);
            if (accountLogin == null)
                return null;

            string passwordSalt = accountLogin.PasswordSalt;
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: Convert.FromBase64String(passwordSalt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8)
            );

            string passwordHash = accountLogin.PasswordHash;
            if (hashedPassword != passwordHash)
                return null;

            return accountLogin.Account;
        }
    }
}
