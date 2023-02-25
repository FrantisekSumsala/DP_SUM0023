using DP_SUM0023.Data.Services.Interfaces;
using DP_SUM0023.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DP_SUM0023.Data.Services.EntityFramework
{
    public class ProjectServiceEF : IProjectService
    {
        private readonly CustomDbContext dbContext;
        public ProjectServiceEF(CustomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await dbContext.Project.ToListAsync();
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            return await dbContext.Project.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(Project instanceToCreate)
        {
            if (instanceToCreate == null)
                return;

            await dbContext.Project.AddAsync(instanceToCreate);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project instanceToUpdate)
        {
            if (instanceToUpdate == null)
                return;

            dbContext.Project.Update(instanceToUpdate);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Project instanceToRemove)
        {
            if (instanceToRemove == null)
                return;

            dbContext.Project.Remove(instanceToRemove);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Project>> GetProjectsNotAssignedToAccount(UserAccount account)
        {
            if (account == null)
                return new List<Project>();

            var assignedProjects = account.AssignedProjects;
            var allProjects = await GetAllAsync();
            return allProjects.Where(p => !assignedProjects.Contains(p)).ToList();
        }
    }
}
