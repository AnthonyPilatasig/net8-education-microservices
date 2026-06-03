using LearningAnalytics.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningAnalytics.Service.Infrastructure.Persistence.Configurations;

public class TipoEventoConfiguration : IEntityTypeConfiguration<TipoEvento>
{
    public void Configure(EntityTypeBuilder<TipoEvento> builder)
    {
        builder.ToTable("tipo_evento");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idTipoEvento");
        
        builder.Property(e => e.NombreEvento)
            .HasMaxLength(90)
            .HasColumnName("nombre_evento");
            
        builder.Property(e => e.Descripcion)
            .HasMaxLength(255)
            .HasColumnName("descripcion");
            
        builder.Property(e => e.EsActivo)
            .HasColumnName("es_activo");
    }
}
