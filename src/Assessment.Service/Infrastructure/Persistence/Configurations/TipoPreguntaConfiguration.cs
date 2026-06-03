using Assessment.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assessment.Service.Infrastructure.Persistence.Configurations;

public class TipoPreguntaConfiguration : IEntityTypeConfiguration<TipoPregunta>
{
    public void Configure(EntityTypeBuilder<TipoPregunta> builder)
    {
        builder.ToTable("tipos_pregunta");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idTiposPregunta");
        
        builder.Property(e => e.NombreTipo)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("nombre_tipo");
            
        builder.Property(e => e.Descripcion)
            .HasMaxLength(255)
            .HasColumnName("descripcion");
            
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");
    }
}
