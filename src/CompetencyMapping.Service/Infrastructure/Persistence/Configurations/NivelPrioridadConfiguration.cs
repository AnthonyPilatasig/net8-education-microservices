using CompetencyMapping.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetencyMapping.Service.Infrastructure.Persistence.Configurations;

public class NivelPrioridadConfiguration : IEntityTypeConfiguration<NivelPrioridad>
{
    public void Configure(EntityTypeBuilder<NivelPrioridad> builder)
    {
        builder.ToTable("niveles_prioridad");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idNivelesPrioridad");
        
        builder.Property(e => e.NombrePrioridad)
            .HasMaxLength(90)
            .HasColumnName("nombre_prioridad");
            
        builder.Property(e => e.ValorPrioridad).HasColumnName("valor_prioridad");
            
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");
    }
}
