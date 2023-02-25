using DP_SUM0023.Data.Services.Interfaces;
using DP_SUM0023.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DP_SUM0023.Data.Services.EntityFramework
{
    public class ReportServiceEF : IReportService
    {
        private readonly CustomDbContext dbContext;

        public ReportServiceEF(CustomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Report>> GetAllAsync()
        {
            return await dbContext.Report.ToListAsync();
        }

        public async Task<Report> GetByIdAsync(int id)
        {
            return await dbContext.Report.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(Report instanceToCreate)
        {
            if (instanceToCreate == null)
                return;

            await dbContext.Report.AddAsync(instanceToCreate);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Report instanceToUpdate)
        {
            if (instanceToUpdate == null)
                return;

            dbContext.Report.Update(instanceToUpdate);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Report instanceToRemove)
        {
            if (instanceToRemove == null)
                return;

            dbContext.Report.Remove(instanceToRemove);
            await dbContext.SaveChangesAsync();
        }
    }
}
