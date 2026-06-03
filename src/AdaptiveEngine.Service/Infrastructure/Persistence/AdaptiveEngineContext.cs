using AdaptiveEngine.Service.Domain.Entities;
using AdaptiveEngine.Service.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AdaptiveEngine.Service.Infrastructure.Persistence;

public class AdaptiveEngineContext : DbContext
{
    public AdaptiveEngineContext(DbContextOptions<AdaptiveEngineContext> options)
        : base(options)
    {
    }

    public DbSet<PerfilEstudiante> PerfilesEstudiantes { get; set; } = null!;
    public DbSet<EstiloAprendizaje> EstilosAprendizaje { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        // Apply Configurations from assembly
        modelBuilder.ApplyConfiguration(new PerfilEstudianteConfiguration());
        modelBuilder.ApplyConfiguration(new EstiloAprendizajeConfiguration());
    }
}
