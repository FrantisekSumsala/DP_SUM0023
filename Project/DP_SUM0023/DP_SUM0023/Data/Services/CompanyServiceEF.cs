using DP_SUM0023.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DP_SUM0023.Data.Services
{
    public class CompanyServiceEF : ICompanyService
    {
        private readonly CustomDbContext dbContext;
        public CompanyServiceEF(CustomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Company>> GetAllCompanies()
        {
            return await dbContext.Company.ToListAsync();
        }

        public async Task CreateCompany(Company newCompany)
        {
            await dbContext.Company.AddAsync(newCompany);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveCompany(Company companyToRemove)
        {
            dbContext.Company.Remove(companyToRemove);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await dbContext.Company.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
