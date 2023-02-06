using DP_SUM0023.Data.Models;

namespace DP_SUM0023.Data.Services
{
    public interface IProcessService
    {
        public Task CreateProcess(Process newProcess);
        public Task RemoveProcess(Process processToRemove);
    }
}
