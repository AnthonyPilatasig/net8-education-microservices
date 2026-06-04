using EducationPlataform.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationPlataform.Service.Infrastructure.Persistence.Configurations;

public class UsuarioEstudianteConfiguration : IEntityTypeConfiguration<UsuarioEstudiante>
{
    public void Configure(EntityTypeBuilder<UsuarioEstudiante> builder)
    {
        builder.ToTable("usuario_estudiante");

        builder.HasKey(e => e.EstudianteId).HasName("PRIMARY");

        builder.Property(e => e.EstudianteId)
            .HasMaxLength(12)
            .HasColumnName("idEstudiante");
            
        builder.Property(e => e.Contrasena)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("contrasena");
            
        builder.Property(e => e.FechaCreacion)
            .HasColumnType("timestamp")
            .HasColumnName("fecha_creacion");
            
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");

        builder.HasOne(d => d.Estudiante)
            .WithOne(p => p.UsuarioEstudiante)
            .HasForeignKey<UsuarioEstudiante>(d => d.EstudianteId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_usuario_estudiante_estudiantes");
            
        builder.HasIndex(e => e.EstudianteId, "fk_usuario_estudiante_estudiantes_idx").IsUnique();
    }
}
