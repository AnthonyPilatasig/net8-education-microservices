using LearningAnalytics.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningAnalytics.Service.Infrastructure.Persistence.Configurations;

public class SesionAprendizajeConfiguration : IEntityTypeConfiguration<SesionAprendizaje>
{
    public void Configure(EntityTypeBuilder<SesionAprendizaje> builder)
    {
        builder.ToTable("sesiones_aprendizaje");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idSesionesAprendizaje");
        
        builder.Property(e => e.EstudianteId)
            .IsRequired()
            .HasMaxLength(12)
            .HasColumnName("idEstudiante");
            
        builder.Property(e => e.FechaInicio)
            .HasColumnType("timestamp")
            .HasColumnName("fecha_inicio");
            
        builder.Property(e => e.FechaFin)
            .HasColumnType("timestamp")
            .HasColumnName("fecha_fin");
            
        builder.Property(e => e.DuracionMinutos)
            .HasColumnName("duracion_minutos");
            
        builder.Property(e => e.ActividadesCompletadas)
            .HasColumnName("actividades_completadas");
            
        builder.Property(e => e.EsActivo)
            .HasColumnName("es_activo");
    }
}
