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
            await dbContext.Project.AddAsync(instanceToCreate);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project instanceToUpdate)
        {
            dbContext.Project.Update(instanceToUpdate);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(Project instanceToRemove)
        {
            dbContext.Project.Remove(instanceToRemove);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Project>> GetProjectsNotAssignedToAccount(UserAccount account)
        {
            var assignedProjects = account.AssignedProjects;
            var allProjects = await GetAllAsync();
            return allProjects.Where(p => !assignedProjects.Contains(p)).ToList();
        }
    }
}
