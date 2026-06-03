using AdaptiveEngine.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdaptiveEngine.Service.Infrastructure.Persistence.Configurations;

public class EstiloAprendizajeConfiguration : IEntityTypeConfiguration<EstiloAprendizaje>
{
    public void Configure(EntityTypeBuilder<EstiloAprendizaje> builder)
    {
        builder.ToTable("estilos_aprendizaje");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idEstilosAprendizaje");
        
        builder.Property(e => e.NombreEstilo)
            .HasMaxLength(150)
            .HasColumnName("nombre_estilo");
            
        builder.Property(e => e.Descripcion)
            .HasMaxLength(255)
            .HasColumnName("descripcion");
            
        builder.Property(e => e.EsActivo)
            .HasColumnName("es_activo");
    }
}
