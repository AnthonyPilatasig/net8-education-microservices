using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CompetencyMapping.Service.Common.Core.Persistence
{
    public abstract class CompetencyDbContext : DbContext
    {
        public CompetencyDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
