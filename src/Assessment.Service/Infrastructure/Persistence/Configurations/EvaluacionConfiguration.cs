using Assessment.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assessment.Service.Infrastructure.Persistence.Configurations;

public class EvaluacionConfiguration : IEntityTypeConfiguration<Evaluacion>
{
    public void Configure(EntityTypeBuilder<Evaluacion> builder)
    {
        builder.ToTable("evaluaciones");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idEvaluaciones");
        
        builder.Property(e => e.CodigoEvaluacion)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("codigo_evaluacion");
            
        builder.Property(e => e.Titulo)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("titulo");
            
        builder.Property(e => e.TipoEvaluacionId).HasColumnName("idTiposEvaluacion");
        builder.Property(e => e.NivelesDificultadId).HasColumnName("idNivelesDificultad");
        builder.Property(e => e.TiempoEstimadoMinutos).HasColumnName("tiempo_estimado_minutos");
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");

        builder.HasOne(d => d.TipoEvaluacion)
            .WithMany(p => p.Evaluaciones)
            .HasForeignKey(d => d.TipoEvaluacionId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_evaluaciones_tipos_evaluacion");
            
        builder.HasIndex(e => e.TipoEvaluacionId, "fk_evaluaciones_tipos_evaluacion_idx");
        builder.HasIndex(e => e.NivelesDificultadId, "fk_evaluaciones_niveles_dificultad1_idx");
    }
}
