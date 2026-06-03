using CompetencyMapping.Service.Domain.Entities;
using CompetencyMapping.Service.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CompetencyMapping.Service.Infrastructure.Persistence;

public class CompetencyMappingContext : DbContext
{
    public CompetencyMappingContext(DbContextOptions<CompetencyMappingContext> options)
        : base(options)
    {
    }

    public DbSet<BrechaAprendizaje> BrechasAprendizaje { get; set; } = null!;
    public DbSet<CategoriaCompetencia> CategoriasCompetencia { get; set; } = null!;
    public DbSet<EstadoDominio> EstadosDominio { get; set; } = null!;
    public DbSet<MapaCompetenciaEstudiante> MapasCompetenciasEstudiante { get; set; } = null!;
    public DbSet<NivelPrioridad> NivelesPrioridad { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.ApplyConfiguration(new BrechaAprendizajeConfiguration());
        modelBuilder.ApplyConfiguration(new CategoriaCompetenciaConfiguration());
        modelBuilder.ApplyConfiguration(new EstadoDominioConfiguration());
        modelBuilder.ApplyConfiguration(new MapaCompetenciaEstudianteConfiguration());
        modelBuilder.ApplyConfiguration(new NivelPrioridadConfiguration());
    }
}
