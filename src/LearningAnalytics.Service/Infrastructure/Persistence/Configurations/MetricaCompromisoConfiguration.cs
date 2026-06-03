using LearningAnalytics.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningAnalytics.Service.Infrastructure.Persistence.Configurations;

public class MetricaCompromisoConfiguration : IEntityTypeConfiguration<MetricaCompromiso>
{
    public void Configure(EntityTypeBuilder<MetricaCompromiso> builder)
    {
        builder.ToTable("metricas_compromiso");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idMetricasCompromiso");
        
        builder.Property(e => e.EstudianteId)
            .IsRequired()
            .HasMaxLength(12)
            .HasColumnName("idEstudiante");
            
        builder.Property(e => e.PuntajeCompromiso)
            .HasPrecision(5, 2)
            .HasDefaultValueSql("'0.00'")
            .HasColumnName("puntaje_compromiso");
            
        builder.Property(e => e.TiempoTotalMinutos)
            .HasColumnName("tiempo_total_minutos");
            
        builder.Property(e => e.ContenidoCompletado)
            .HasColumnName("contenido_completado");
            
        builder.Property(e => e.FechaCalculo)
            .HasColumnType("timestamp")
            .HasColumnName("fecha_calculo");
            
        builder.Property(e => e.EsActivo)
            .HasColumnName("es_activo");
    }
}
