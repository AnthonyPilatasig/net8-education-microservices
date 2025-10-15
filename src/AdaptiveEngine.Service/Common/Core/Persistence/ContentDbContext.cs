using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AdaptiveEngine.Service.Common.Core.Persistence
{
    public abstract class AdaptiveEngineDbContext : DbContext
    {
        public AdaptiveEngineDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
