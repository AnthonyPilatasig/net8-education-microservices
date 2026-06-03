using EducationPlataform.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationPlataform.Service.Infrastructure.Persistence.Configurations;

public class InscripcionConfiguration : IEntityTypeConfiguration<Inscripcion>
{
    public void Configure(EntityTypeBuilder<Inscripcion> builder)
    {
        builder.ToTable("inscripciones");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idInscripciones");
        
        builder.Property(e => e.EstudianteId)
            .IsRequired()
            .HasMaxLength(12)
            .HasColumnName("idEstudiante");
            
        builder.Property(e => e.CursoId).HasColumnName("idCursos");
        
        builder.Property(e => e.FechaInscripcion)
            .HasColumnType("timestamp")
            .HasColumnName("fecha_inscripcion");
            
        builder.Property(e => e.EstadoInscripcion)
            .HasMaxLength(50)
            .HasDefaultValueSql("'ACTIVA'")
            .HasColumnName("estado_inscripcion");
            
        builder.Property(e => e.ProgresoPorcentaje)
            .HasPrecision(5, 2)
            .HasDefaultValueSql("'0.00'")
            .HasColumnName("progreso_porcentaje");
            
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");

        builder.HasOne(d => d.Curso)
            .WithMany()
            .HasForeignKey(d => d.CursoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_inscripciones_cursos1");

        builder.HasOne(d => d.Estudiante)
            .WithMany(p => p.Inscripciones)
            .HasForeignKey(d => d.EstudianteId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_inscripciones_usuario_estudiante1");
            
        builder.HasIndex(e => e.CursoId, "fk_inscripciones_cursos1_idx");
        builder.HasIndex(e => e.EstudianteId, "fk_inscripciones_usuario_estudiante1_idx");
    }
}
