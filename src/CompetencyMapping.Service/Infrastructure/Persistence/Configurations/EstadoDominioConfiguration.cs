using CompetencyMapping.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetencyMapping.Service.Infrastructure.Persistence.Configurations;

public class EstadoDominioConfiguration : IEntityTypeConfiguration<EstadoDominio>
{
    public void Configure(EntityTypeBuilder<EstadoDominio> builder)
    {
        builder.ToTable("estados_dominio");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idEstadosDominio");
        
        builder.Property(e => e.NombreEstado)
            .HasMaxLength(90)
            .HasColumnName("nombre_estado");
            
        builder.Property(e => e.Descripcion)
            .HasMaxLength(255)
            .HasColumnName("descripcion");
            
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");
    }
}
