using CompetencyMapping.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetencyMapping.Service.Infrastructure.Persistence.Configurations;

public class CategoriaCompetenciaConfiguration : IEntityTypeConfiguration<CategoriaCompetencia>
{
    public void Configure(EntityTypeBuilder<CategoriaCompetencia> builder)
    {
        builder.ToTable("categorias_competencia");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idCategoriasCompetencia");
        
        builder.Property(e => e.NombreCategoria)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("nombre_categoria");
            
        builder.Property(e => e.Descripcion)
            .HasMaxLength(255)
            .HasColumnName("descripcion");
            
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");
    }
}
