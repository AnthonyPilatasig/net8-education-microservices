using CompetencyMapping.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetencyMapping.Service.Infrastructure.Persistence.Configurations;

public class BrechaAprendizajeConfiguration : IEntityTypeConfiguration<BrechaAprendizaje>
{
    public void Configure(EntityTypeBuilder<BrechaAprendizaje> builder)
    {
        builder.ToTable("brechas_aprendizaje");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idBrechasAprendizaje");
        
        builder.Property(e => e.EstudianteId)
            .IsRequired()
            .HasMaxLength(12)
            .HasColumnName("idEstudiante");
            
        builder.Property(e => e.CompetenciaId).HasColumnName("idCompetencias");
        builder.Property(e => e.NivelPrioridadId).HasColumnName("idNivelesPrioridad");
        
        builder.Property(e => e.NivelActual)
            .HasPrecision(4, 2)
            .HasColumnName("nivel_actual");
            
        builder.Property(e => e.NivelRequerido)
            .HasPrecision(4, 2)
            .HasColumnName("nivel_requerido");
            
        builder.Property(e => e.FechaDeteccion)
            .HasColumnType("timestamp")
            .HasColumnName("fecha_deteccion");
            
        builder.Property(e => e.EsActiva).HasColumnName("es_activa");

        builder.HasOne(d => d.NivelPrioridad)
            .WithMany()
            .HasForeignKey(d => d.NivelPrioridadId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_brechas_aprendizaje_niveles_prioridad1");
            
        builder.HasIndex(e => e.CompetenciaId, "fk_brechas_aprendizaje_Competencias1_idx");
        builder.HasIndex(e => e.NivelPrioridadId, "fk_brechas_aprendizaje_niveles_prioridad1_idx");
    }
}
