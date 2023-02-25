using DP_SUM0023.Data.Services.Interfaces;
using DP_SUM0023.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DP_SUM0023.Data.Services.EntityFramework
{
    public class CompanyServiceEF : ICompanyService
    {
        private readonly CustomDbContext dbContext;
        public CompanyServiceEF(CustomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await dbContext.Company.ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await dbContext.Company.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(Company instanceToCreate)
        {
            if (instanceToCreate == null)
                return;

            await dbContext.Company.AddAsync(instanceToCreate);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company instanceToUpdate)
        {
            if (instanceToUpdate == null)
                return;

            dbContext.Company.Update(instanceToUpdate);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Company instanceToRemove)
        {
            if (instanceToRemove == null)
                return;

            dbContext.Company.Remove(instanceToRemove);
            await dbContext.SaveChangesAsync();
        }

    }
}
