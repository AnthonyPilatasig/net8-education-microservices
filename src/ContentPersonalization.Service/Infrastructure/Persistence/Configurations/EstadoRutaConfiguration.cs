using ContentPersonalization.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContentPersonalization.Service.Infrastructure.Persistence.Configurations;

public class EstadoRutaConfiguration : IEntityTypeConfiguration<EstadoRuta>
{
    public void Configure(EntityTypeBuilder<EstadoRuta> builder)
    {
        builder.ToTable("estados_ruta");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idEstadosRuta");
        
        builder.Property(e => e.NombreEstado)
            .IsRequired()
            .HasMaxLength(90)
            .HasColumnName("nombre_estado");
            
        builder.Property(e => e.Descripcion)
            .HasMaxLength(255)
            .HasColumnName("descripcion");
            
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");
    }
}
