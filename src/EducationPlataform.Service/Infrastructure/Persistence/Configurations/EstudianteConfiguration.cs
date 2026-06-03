using EducationPlataform.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationPlataform.Service.Infrastructure.Persistence.Configurations;

public class EstudianteConfiguration : IEntityTypeConfiguration<Estudiante>
{
    public void Configure(EntityTypeBuilder<Estudiante> builder)
    {
        builder.ToTable("estudiantes");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id)
            .HasMaxLength(12)
            .HasColumnName("idEstudiante");
            
        builder.Property(e => e.CodigoEstudiante)
            .HasMaxLength(20)
            .HasColumnName("codigo_estudiante");
            
        builder.Property(e => e.PrimerNombre)
            .HasMaxLength(100)
            .HasColumnName("primer_nombre");
            
        builder.Property(e => e.SegundoNombre)
            .HasMaxLength(100)
            .HasColumnName("segundo_nombre");
            
        builder.Property(e => e.PrimerApellido)
            .HasMaxLength(100)
            .HasColumnName("primer_apellido");
            
        builder.Property(e => e.SegundoApellido)
            .HasMaxLength(100)
            .HasColumnName("segundo_apellido");
            
        builder.Property(e => e.Email)
            .HasMaxLength(150)
            .HasColumnName("email");
            
        builder.Property(e => e.FechaRegistro)
            .HasColumnType("timestamp")
            .HasColumnName("fecha_registro");
            
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");

        builder.HasIndex(e => e.Id, "idEstudiante_UNIQUE").IsUnique();
    }
}
