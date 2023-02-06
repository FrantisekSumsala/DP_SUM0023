using DP_SUM0023.Data.Models;

namespace DP_SUM0023.Data.Services
{
    public interface ICompanyService
    {
        public Task<List<Company>> GetAllCompanies();
        public Task<Company> GetCompanyById(int id);
        public Task CreateCompany(Company newCompany);
        public Task RemoveCompany(Company companyToRemove);

    }
}
