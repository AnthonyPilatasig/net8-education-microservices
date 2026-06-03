using AdaptiveEngine.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdaptiveEngine.Service.Infrastructure.Persistence.Configurations;

public class PerfilEstudianteConfiguration : IEntityTypeConfiguration<PerfilEstudiante>
{
    public void Configure(EntityTypeBuilder<PerfilEstudiante> builder)
    {
        builder.ToTable("perfiles_estudiantes");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idPerfilesEstudiantes");
        
        builder.Property(e => e.EstudianteId)
            .IsRequired()
            .HasMaxLength(12)
            .HasColumnName("idEstudiante");
            
        builder.Property(e => e.EstiloAprendizajeId)
            .HasColumnName("idEstilosAprendizaje");
            
        builder.Property(e => e.NivelActual)
            .HasPrecision(4, 2)
            .HasColumnName("nivel_actual");
            
        builder.Property(e => e.VelocidadAprendizaje)
            .HasPrecision(4, 2)
            .HasColumnName("velocidad_aprendizaje");
            
        builder.Property(e => e.FechaActualizacion)
            .HasColumnType("timestamp")
            .HasColumnName("fecha_actualizacion");
            
        builder.Property(e => e.EsActivo)
            .HasColumnName("es_activo");

        // Relaciones
        builder.HasOne(d => d.EstiloAprendizaje)
            .WithMany(p => p.PerfilesEstudiantes)
            .HasForeignKey(d => d.EstiloAprendizajeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_perfiles_estudiantes_estilos_aprendizaje");
            
        builder.HasIndex(e => e.EstiloAprendizajeId, "fk_perfiles_estudiantes_estilos_aprendizaje_idx");
    }
}
