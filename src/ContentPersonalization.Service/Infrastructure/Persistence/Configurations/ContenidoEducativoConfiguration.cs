using ContentPersonalization.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContentPersonalization.Service.Infrastructure.Persistence.Configurations;

public class ContenidoEducativoConfiguration : IEntityTypeConfiguration<ContenidoEducativo>
{
    public void Configure(EntityTypeBuilder<ContenidoEducativo> builder)
    {
        builder.ToTable("contenidos_educativos");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idContenidosEducativos");
        
        builder.Property(e => e.CodigoContenido)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("codigo_contenido");
            
        builder.Property(e => e.Titulo)
            .IsRequired()
            .HasMaxLength(300)
            .HasColumnName("titulo");
            
        builder.Property(e => e.TipoContenidoId).HasColumnName("idTiposContenido");
        builder.Property(e => e.NivelDificultadId).HasColumnName("idNivelesDificultad");
        builder.Property(e => e.DuracionMinutos).HasColumnName("duracion_minutos");
        
        builder.Property(e => e.UrlRecurso)
            .HasMaxLength(500)
            .HasColumnName("url_recurso");
            
        builder.Property(e => e.EtiquetasJson)
            .HasColumnType("json")
            .HasColumnName("etiquetas_json");
            
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");

        builder.HasOne(d => d.NivelDificultad)
            .WithMany()
            .HasForeignKey(d => d.NivelDificultadId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_contenidos_educativos_niveles_dificultad1");

        builder.HasOne(d => d.TipoContenido)
            .WithMany()
            .HasForeignKey(d => d.TipoContenidoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_contenidos_educativos_tipos_contenido");
            
        builder.HasIndex(e => e.CodigoContenido, "codigo_contenido_UNIQUE").IsUnique();
        builder.HasIndex(e => e.NivelDificultadId, "fk_contenidos_educativos_niveles_dificultad1_idx");
        builder.HasIndex(e => e.TipoContenidoId, "fk_contenidos_educativos_tipos_contenido_idx");
    }
}
