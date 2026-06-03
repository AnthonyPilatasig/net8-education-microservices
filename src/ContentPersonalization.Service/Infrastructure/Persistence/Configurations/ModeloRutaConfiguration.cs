using ContentPersonalization.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContentPersonalization.Service.Infrastructure.Persistence.Configurations;

public class ModeloRutaConfiguration : IEntityTypeConfiguration<ModeloRuta>
{
    public void Configure(EntityTypeBuilder<ModeloRuta> builder)
    {
        builder.ToTable("modelos_ruta");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idModelosRuta");
        
        builder.Property(e => e.RutaAprendizajeId).HasColumnName("idRutasAprendizaje");
        builder.Property(e => e.ContenidoId).HasColumnName("idContenido");
        builder.Property(e => e.OrdenModulo).HasColumnName("orden_modulo");
        
        builder.Property(e => e.FechaAsignacion)
            .HasColumnType("timestamp")
            .HasColumnName("fecha_asignacion");
            
        builder.Property(e => e.FechaCompletacion)
            .HasColumnType("timestamp")
            .HasColumnName("fecha_completacion");
            
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");

        builder.HasOne(d => d.RutaAprendizaje)
            .WithMany(p => p.ModelosRuta)
            .HasForeignKey(d => d.RutaAprendizajeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_modelos_ruta_rutas_aprendizaje1");
            
        builder.HasIndex(e => e.RutaAprendizajeId, "fk_modelos_ruta_rutas_aprendizaje1_idx");
    }
}
