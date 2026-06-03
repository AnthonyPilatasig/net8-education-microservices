using Assessment.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assessment.Service.Infrastructure.Persistence.Configurations;

public class PreguntaConfiguration : IEntityTypeConfiguration<Pregunta>
{
    public void Configure(EntityTypeBuilder<Pregunta> builder)
    {
        builder.ToTable("preguntas");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idPreguntas");
        
        builder.Property(e => e.EvaluacionId).HasColumnName("idEvaluaciones");
        builder.Property(e => e.TipoPreguntaId).HasColumnName("idTiposPregunta");
        
        builder.Property(e => e.TextoPregunta)
            .HasColumnType("text")
            .HasColumnName("texto_pregunta");
            
        builder.Property(e => e.PreguntasJson)
            .HasColumnType("json")
            .HasColumnName("preguntas_json");
            
        builder.Property(e => e.RespuestaCorrecta)
            .HasMaxLength(500)
            .HasColumnName("respuesta_correcta");
            
        builder.Property(e => e.OrdenPregunta).HasColumnName("orden_pregunta");
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");

        builder.HasOne(d => d.Evaluacion)
            .WithMany(p => p.Preguntas)
            .HasForeignKey(d => d.EvaluacionId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_preguntas_evaluaciones1");

        builder.HasOne(d => d.TipoPregunta)
            .WithMany(p => p.Preguntas)
            .HasForeignKey(d => d.TipoPreguntaId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_preguntas_tipos_pregunta1");
            
        builder.HasIndex(e => e.EvaluacionId, "fk_preguntas_evaluaciones1_idx");
        builder.HasIndex(e => e.TipoPreguntaId, "fk_preguntas_tipos_pregunta1_idx");
    }
}
