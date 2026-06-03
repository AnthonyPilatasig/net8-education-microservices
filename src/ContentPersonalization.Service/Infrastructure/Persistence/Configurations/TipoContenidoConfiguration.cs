using ContentPersonalization.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContentPersonalization.Service.Infrastructure.Persistence.Configurations;

public class TipoContenidoConfiguration : IEntityTypeConfiguration<TipoContenido>
{
    public void Configure(EntityTypeBuilder<TipoContenido> builder)
    {
        builder.ToTable("tipos_contenido");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idTiposContenido");
        
        builder.Property(e => e.NombreTipo)
            .IsRequired()
            .HasMaxLength(90)
            .HasColumnName("nombre_tipo");
            
        builder.Property(e => e.Descripcion)
            .HasMaxLength(255)
            .HasColumnName("descripcion");
            
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");
    }
}
