using DP_SUM0023.Data.Services.Interfaces;
using DP_SUM0023.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DP_SUM0023.Data.Services.EntityFramework
{
    public class ProcessServiceEF : IProcessService
    {
        private readonly CustomDbContext dbContext;
        public ProcessServiceEF(CustomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Process>> GetAllAsync()
        {
            return await dbContext.Process.ToListAsync();
        }

        public async Task<Process> GetByIdAsync(int id)
        {
            return await dbContext.Process.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(Process instanceToCreate)
        {
            if (instanceToCreate == null)
                return;

            await dbContext.Process.AddAsync(instanceToCreate);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Process instanceToUpdate)
        {
            if (instanceToUpdate == null)
                return;

            dbContext.Process.Update(instanceToUpdate);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Process instanceToRemove)
        {
            if (instanceToRemove == null)
                return;

            dbContext.Process.Remove(instanceToRemove);
            await dbContext.SaveChangesAsync();
        }

    }
}
