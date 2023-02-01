﻿using DP_SUM0023.Data.Models;

namespace DP_SUM0023.Data.Services
{
    public interface IUserAccountService
    {
        public Task<UserAccount> AuthenticateUser(string username, string password);
    }
}
