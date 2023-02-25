using DP_SUM0023.Data.Models;

namespace DP_SUM0023.Data.Services.Interfaces
{
    public interface IUserAccountService : IDefaultCRUDService<UserAccount>
    {
        public Task<UserAccount> AuthenticateUser(string username, string password);
        public Task<string> GetAccountUsername(UserAccount account);
        public Task<UserAccount> GetByUsername(string username);
        public Task RegisterUser(UserAccountLogin login);
    }
}
