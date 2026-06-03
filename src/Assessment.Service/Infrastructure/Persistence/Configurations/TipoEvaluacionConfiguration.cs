using Assessment.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assessment.Service.Infrastructure.Persistence.Configurations;

public class TipoEvaluacionConfiguration : IEntityTypeConfiguration<TipoEvaluacion>
{
    public void Configure(EntityTypeBuilder<TipoEvaluacion> builder)
    {
        builder.ToTable("tipos_evaluacion");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idTiposEvaluacion");
        
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
