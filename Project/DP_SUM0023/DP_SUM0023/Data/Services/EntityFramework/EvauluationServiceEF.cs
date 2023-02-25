using DP_SUM0023.Data.Services.Interfaces;
using DP_SUM0023.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DP_SUM0023.Data.Services.EntityFramework
{
    public class EvauluationServiceEF : IEvaluationService
    {
        private readonly CustomDbContext dbContext;

        public EvauluationServiceEF(CustomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Evaluation>> GetAllAsync()
        {
            return await dbContext.Evaluation.ToListAsync();
        }

        public async Task<Evaluation> GetByIdAsync(int id)
        {
            return await dbContext.Evaluation.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(Evaluation instanceToCreate)
        {
            if (instanceToCreate == null)
                return;

            await dbContext.Evaluation.AddAsync(instanceToCreate);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Evaluation instanceToUpdate)
        {
            if (instanceToUpdate == null)
                return;

            dbContext.Evaluation.Update(instanceToUpdate);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Evaluation instanceToRemove)
        {
            if (instanceToRemove == null)
                return;

            dbContext.Evaluation.Remove(instanceToRemove);
            await dbContext.SaveChangesAsync();
        }
    }
}
