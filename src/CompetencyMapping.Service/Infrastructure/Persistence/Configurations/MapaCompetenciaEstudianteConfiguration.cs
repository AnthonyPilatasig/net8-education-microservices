using CompetencyMapping.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompetencyMapping.Service.Infrastructure.Persistence.Configurations;

public class MapaCompetenciaEstudianteConfiguration : IEntityTypeConfiguration<MapaCompetenciaEstudiante>
{
    public void Configure(EntityTypeBuilder<MapaCompetenciaEstudiante> builder)
    {
        builder.ToTable("mapa_competencias_estudiante");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idMapaCompetenciasEstudiante");
        
        builder.Property(e => e.EstudianteId)
            .IsRequired()
            .HasMaxLength(12)
            .HasColumnName("idEstudiante");
            
        builder.Property(e => e.CompetenciaId).HasColumnName("idCompetencias");
        builder.Property(e => e.EstadoDominioId).HasColumnName("idEstadosDominio");
        
        builder.Property(e => e.NivelDominio)
            .HasPrecision(4, 2)
            .HasColumnName("nivel_dominio");
            
        builder.Property(e => e.Confianza)
            .HasPrecision(4, 2)
            .HasColumnName("confianza");
            
        builder.Property(e => e.FechaEvaluacion)
            .HasColumnType("timestamp")
            .HasColumnName("fecha_evaluacion");
            
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");

        builder.HasOne(d => d.EstadoDominio)
            .WithMany()
            .HasForeignKey(d => d.EstadoDominioId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_mapa_competencias_estudiante_estados_dominio1");
            
        builder.HasIndex(e => e.CompetenciaId, "fk_mapa_competencias_estudiante_Competencias1_idx");
        builder.HasIndex(e => e.EstadoDominioId, "fk_mapa_competencias_estudiante_estados_dominio1_idx");
    }
}
