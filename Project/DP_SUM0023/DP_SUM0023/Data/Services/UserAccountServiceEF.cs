using Microsoft.EntityFrameworkCore;
using DP_SUM0023.Data.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DP_SUM0023.Data.Services
{
    public class UserAccountServiceEF : IUserAccountService
    {
        private readonly CustomDbContext dbContext;

        public UserAccountServiceEF(CustomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<UserAccount>> GetAllAsync()
        {
            return await dbContext.Account.ToListAsync();
        }

        public async Task<UserAccount> GetByIdAsync(int id)
        {
            return await dbContext.Account.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(UserAccount instanceToCreate)
        {
            await dbContext.Account.AddAsync(instanceToCreate);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserAccount instanceToUpdate)
        {
            dbContext.Account.Update(instanceToUpdate);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(UserAccount instanceToRemove)
        {
            dbContext.Account.Remove(instanceToRemove);
            await dbContext.SaveChangesAsync();
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

        public async Task<string> GetAccountUsername(UserAccount account)
        {
            var accountLogin = await dbContext.AccountLogin.SingleOrDefaultAsync(login => login.Account == account);
            if (accountLogin == null)
                return "Not found";

            return accountLogin.Username;
        }

    }
}
