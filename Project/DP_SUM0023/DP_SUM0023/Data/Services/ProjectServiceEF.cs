using DP_SUM0023.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DP_SUM0023.Data.Services
{
    public class ProjectServiceEF : IProjectService
    {
        private readonly CustomDbContext dbContext;
        public ProjectServiceEF(CustomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task RemoveProject(Project projectToRemove)
        {
            dbContext.Project.Remove(projectToRemove);
            await dbContext.SaveChangesAsync();
        }

        public async Task CreateProject(Project newProject)
        {
            await dbContext.Project.AddAsync(newProject);
            await dbContext.SaveChangesAsync();
        }

        public async Task<Project> GetProjectById(int projectId)
        {
            return await dbContext.Project.SingleOrDefaultAsync(x => x.Id == projectId);
        }
    }
}
