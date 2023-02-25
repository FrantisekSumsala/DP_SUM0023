using DP_SUM0023.Data.Services.Interfaces;
using DP_SUM0023.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DP_SUM0023.Data.Services.EntityFramework
{
    public class ProcessEvauluationServiceEF : IProcessEvaluationService
    {
        private readonly CustomDbContext dbContext;

        public ProcessEvauluationServiceEF(CustomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<ProcessEvaluation>> GetAllAsync()
        {
            return await dbContext.ProcessEvaluation.ToListAsync();
        }

        public async Task<ProcessEvaluation> GetByIdAsync(int id)
        {
            return await dbContext.ProcessEvaluation.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(ProcessEvaluation instanceToCreate)
        {
            if (instanceToCreate == null)
                return;

            await dbContext.ProcessEvaluation.AddAsync(instanceToCreate);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProcessEvaluation instanceToUpdate)
        {
            if (instanceToUpdate == null)
                return;

            dbContext.ProcessEvaluation.Update(instanceToUpdate);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(ProcessEvaluation instanceToRemove)
        {
            if (instanceToRemove == null)
                return;

            dbContext.ProcessEvaluation.Remove(instanceToRemove);
            await dbContext.SaveChangesAsync();
        }
    }
}
