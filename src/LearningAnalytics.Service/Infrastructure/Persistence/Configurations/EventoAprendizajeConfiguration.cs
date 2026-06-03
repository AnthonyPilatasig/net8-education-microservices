using LearningAnalytics.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningAnalytics.Service.Infrastructure.Persistence.Configurations;

public class EventoAprendizajeConfiguration : IEntityTypeConfiguration<EventoAprendizaje>
{
    public void Configure(EntityTypeBuilder<EventoAprendizaje> builder)
    {
        builder.ToTable("eventos_aprendizaje");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idEventosAprendizaje");
        
        builder.Property(e => e.EstudianteId)
            .IsRequired()
            .HasMaxLength(12)
            .HasColumnName("idEstudiante");
            
        builder.Property(e => e.ContenidoId).HasColumnName("idContenido");
        
        builder.Property(e => e.TipoEventoId).HasColumnName("idTipoEvento");
            
        builder.Property(e => e.FechaEvento)
            .HasColumnType("timestamp")
            .HasColumnName("fecha_evento");
            
        builder.Property(e => e.MetadatosJson)
            .HasColumnType("json")
            .HasColumnName("metadatos_json");
            
        builder.Property(e => e.EsActivo)
            .HasColumnName("es_activo");

        builder.HasOne(d => d.TipoEvento)
            .WithMany(p => p.EventosAprendizaje)
            .HasForeignKey(d => d.TipoEventoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_eventos_aprendizaje_TipoEvento");
            
        builder.HasIndex(e => e.TipoEventoId, "fk_eventos_aprendizaje_TipoEvento_idx");
    }
}
