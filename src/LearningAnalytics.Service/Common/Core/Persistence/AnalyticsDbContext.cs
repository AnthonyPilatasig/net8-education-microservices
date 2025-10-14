using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LearningAnalytics.Service.Common.Core.Persistence
{
    public abstract class AnalyticsDbContext : DbContext
    {
        public AnalyticsDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}