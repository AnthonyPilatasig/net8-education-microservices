using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ContentPersonalization.Service.Common.Core.Persistence
{
    public abstract class ContentDbContext : DbContext
    {
        public ContentDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
