using Assessment.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assessment.Service.Infrastructure.Persistence.Configurations;

public class ResultadoEvaluacionConfiguration : IEntityTypeConfiguration<ResultadoEvaluacion>
{
    public void Configure(EntityTypeBuilder<ResultadoEvaluacion> builder)
    {
        builder.ToTable("resultados_evaluacion");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idResultadosEvaluacion");
        
        builder.Property(e => e.EstudianteId)
            .IsRequired()
            .HasMaxLength(12)
            .HasColumnName("idEstudiante");
            
        builder.Property(e => e.EvaluacionId).HasColumnName("idEvaluaciones");
        
        builder.Property(e => e.PuntajeObtenido)
            .HasPrecision(6, 2)
            .HasColumnName("puntaje_obtenido");
            
        builder.Property(e => e.PuntajeMaximo)
            .HasPrecision(6, 2)
            .HasColumnName("puntaje_maximo");
            
        builder.Property(e => e.TiempoEmpleadoMinutos).HasColumnName("tiempo_empleado_minutos");
        
        builder.Property(e => e.FechaCompletacion)
            .HasColumnType("timestamp")
            .HasColumnName("fecha_completacion");
            
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");

        builder.HasOne(d => d.Evaluacion)
            .WithMany(p => p.ResultadosEvaluacion)
            .HasForeignKey(d => d.EvaluacionId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_resultados_evaluacion_evaluaciones1");
            
        builder.HasIndex(e => e.EvaluacionId, "fk_resultados_evaluacion_evaluaciones1_idx");
    }
}
