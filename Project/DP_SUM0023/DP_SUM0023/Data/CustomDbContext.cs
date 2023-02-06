using Microsoft.EntityFrameworkCore;
using DP_SUM0023.Data.Models;

namespace DP_SUM0023.Data
{
    public class CustomDbContext : DbContext
    {
        public DbSet<UserAccount> Account { get; set; }
        public DbSet<UserAccountLogin> AccountLogin { get; set; }
        public DbSet<UserAccountRole> AccountRole { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<ProcessEvaluation> ProcessEvaluation { get; set; }

        public CustomDbContext(DbContextOptions<CustomDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
