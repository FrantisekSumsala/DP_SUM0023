using DP_SUM0023.Data.Models;

namespace DP_SUM0023.Data.Services
{
    public interface IProjectService
    {
        public Task RemoveProject(Project projectToRemove);
        public Task CreateProject(Project newProject);
        public Task<Project> GetProjectById(int projectId);
    }
}
