using LearningAnalytics.Service.Domain.Entities;
using LearningAnalytics.Service.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LearningAnalytics.Service.Infrastructure.Persistence;

public class LearningAnalyticsContext : DbContext
{
    public LearningAnalyticsContext(DbContextOptions<LearningAnalyticsContext> options)
        : base(options)
    {
    }

    public DbSet<EventoAprendizaje> EventosAprendizaje { get; set; } = null!;
    public DbSet<MetricaCompromiso> MetricasCompromiso { get; set; } = null!;
    public DbSet<SesionAprendizaje> SesionesAprendizaje { get; set; } = null!;
    public DbSet<TipoEvento> TipoEvento { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.ApplyConfiguration(new EventoAprendizajeConfiguration());
        modelBuilder.ApplyConfiguration(new MetricaCompromisoConfiguration());
        modelBuilder.ApplyConfiguration(new SesionAprendizajeConfiguration());
        modelBuilder.ApplyConfiguration(new TipoEventoConfiguration());
    }
}
