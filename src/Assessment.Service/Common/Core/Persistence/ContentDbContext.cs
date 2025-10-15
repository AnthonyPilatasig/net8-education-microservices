using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Assessment.Service.Common.Core.Persistence
{
    public abstract class AssessmentDbContext : DbContext
    {
        public AssessmentDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
