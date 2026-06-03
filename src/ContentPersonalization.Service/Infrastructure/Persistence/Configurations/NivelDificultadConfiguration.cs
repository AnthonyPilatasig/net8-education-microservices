using ContentPersonalization.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContentPersonalization.Service.Infrastructure.Persistence.Configurations;

public class NivelDificultadConfiguration : IEntityTypeConfiguration<NivelDificultad>
{
    public void Configure(EntityTypeBuilder<NivelDificultad> builder)
    {
        builder.ToTable("niveles_dificultad");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idNivelesDificultad");
        
        builder.Property(e => e.NombreNivel)
            .IsRequired()
            .HasMaxLength(90)
            .HasColumnName("nombre_nivel");
            
        builder.Property(e => e.ValorMinimo)
            .HasPrecision(4, 2)
            .HasColumnName("valor_minimo");
            
        builder.Property(e => e.ValorMaximo)
            .HasPrecision(4, 2)
            .HasColumnName("valor_maximo");
            
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");
    }
}
