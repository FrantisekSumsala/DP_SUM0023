using DP_SUM0023.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DP_SUM0023.Data.Services
{
    public class UserAccountRoleServiceEF : IUserAccountRoleService
    {
        private readonly CustomDbContext dbContext;

        public UserAccountRoleServiceEF(CustomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<UserAccountRole>> GetAllAsync()
        {
            return await dbContext.AccountRole.ToListAsync();
        }

        public async Task<UserAccountRole> GetByIdAsync(int id)
        {
            return await dbContext.AccountRole.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(UserAccountRole instanceToCreate)
        {
            await dbContext.AccountRole.AddAsync(instanceToCreate);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserAccountRole instanceToUpdate)
        {
            dbContext.AccountRole.Update(instanceToUpdate);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(UserAccountRole instanceToRemove)
        {
            dbContext.AccountRole.Remove(instanceToRemove);
            await dbContext.SaveChangesAsync();
        }

        public async Task<UserAccountRole> GetByEnum(EAccountRole enumRole)
        {
            var dbRole = await dbContext.AccountRole.SingleOrDefaultAsync(x => x.Name == enumRole.ToString());
            return dbRole;
        }

        public EAccountRole ToEnumRole(UserAccountRole dbRole)
        {
            switch (dbRole.Name)
            {
                case "Admin":
                    return EAccountRole.Admin;
                case "Editor":
                    return EAccountRole.Editor;
                default:
                    return EAccountRole.Reader;
            }
        }
    }
}
