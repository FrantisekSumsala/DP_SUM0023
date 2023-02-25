using DP_SUM0023.Data.Models;

namespace DP_SUM0023.Data.Services.Interfaces
{
    public interface IProjectService : IDefaultCRUDService<Project>
    {
        public Task<List<Project>> GetProjectsNotAssignedToAccount(UserAccount account);
    }
}
