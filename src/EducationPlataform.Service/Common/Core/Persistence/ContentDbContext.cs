using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EducationPlataform.Service.Common.Core.Persistence
{
    public abstract class EducationDbContext : DbContext
    {
        public EducationDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
