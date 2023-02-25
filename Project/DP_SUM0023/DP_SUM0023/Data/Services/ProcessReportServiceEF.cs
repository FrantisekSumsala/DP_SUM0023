﻿using DP_SUM0023.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DP_SUM0023.Data.Services
{
    public class ProcessReportServiceEF : IProcessReportService
    {
        private readonly CustomDbContext dbContext;

        public ProcessReportServiceEF(CustomDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<ProcessReport>> GetAllAsync()
        {
            return await dbContext.ProcessReport.ToListAsync();
        }

        public async Task<ProcessReport> GetByIdAsync(int id)
        {
            return await dbContext.ProcessReport.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(ProcessReport instanceToCreate)
        {
            await dbContext.ProcessReport.AddAsync(instanceToCreate);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProcessReport instanceToUpdate)
        {
            dbContext.ProcessReport.Update(instanceToUpdate);
            await dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(ProcessReport instanceToRemove)
        {
            dbContext.ProcessReport.Remove(instanceToRemove);
            await dbContext.SaveChangesAsync();
        }
    }
}
