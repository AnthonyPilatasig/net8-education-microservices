using ContentPersonalization.Service.Domain.Entities;
using ContentPersonalization.Service.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ContentPersonalization.Service.Infrastructure.Persistence;

public class ContentPersonalizationContext : DbContext
{
    public ContentPersonalizationContext(DbContextOptions<ContentPersonalizationContext> options)
        : base(options)
    {
    }

    public DbSet<ContenidoEducativo> ContenidosEducativos { get; set; } = null!;
    public DbSet<EstadoRuta> EstadosRuta { get; set; } = null!;
    public DbSet<ModeloRuta> ModelosRuta { get; set; } = null!;
    public DbSet<NivelDificultad> NivelesDificultad { get; set; } = null!;
    public DbSet<RutaAprendizaje> RutasAprendizaje { get; set; } = null!;
    public DbSet<TipoContenido> TiposContenido { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.ApplyConfiguration(new ContenidoEducativoConfiguration());
        modelBuilder.ApplyConfiguration(new EstadoRutaConfiguration());
        modelBuilder.ApplyConfiguration(new ModeloRutaConfiguration());
        modelBuilder.ApplyConfiguration(new NivelDificultadConfiguration());
        modelBuilder.ApplyConfiguration(new RutaAprendizajeConfiguration());
        modelBuilder.ApplyConfiguration(new TipoContenidoConfiguration());
    }
}
