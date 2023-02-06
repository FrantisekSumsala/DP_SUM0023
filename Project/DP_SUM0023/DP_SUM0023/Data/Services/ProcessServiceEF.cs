using DP_SUM0023.Data.Models;

namespace DP_SUM0023.Data.Services
{
    public class ProcessServiceEF : IProcessService
    {
        private readonly CustomDbContext dbContext;
        public ProcessServiceEF(CustomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateProcess(Process newProcess)
        {
            await dbContext.Process.AddAsync(newProcess);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveProcess(Process processToRemove)
        {
            dbContext.Process.Remove(processToRemove);
            await dbContext.SaveChangesAsync();
        }
    }
}
