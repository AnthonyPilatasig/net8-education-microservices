using EducationPlataform.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationPlataform.Service.Infrastructure.Persistence.Configurations;

public class CursoConfiguration : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.ToTable("cursos");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idCursos");
        
        builder.Property(e => e.CodigoCurso)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("codigo_curso");
            
        builder.Property(e => e.NombreCurso)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("nombre_curso");
            
        builder.Property(e => e.Descripcion)
            .HasColumnType("text")
            .HasColumnName("descripcion");
            
        builder.Property(e => e.DuracionHoras)
            .HasPrecision(5, 2)
            .HasColumnName("duracion_horas");
            
        builder.Property(e => e.NivelDificultad)
            .HasMaxLength(50)
            .HasColumnName("nivel_dificultad");
            
        builder.Property(e => e.Categoria)
            .HasMaxLength(100)
            .HasColumnName("categoria");
            
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");

        builder.HasIndex(e => e.CodigoCurso, "codigo_curso_UNIQUE").IsUnique();
    }
}
