using ContentPersonalization.Service.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContentPersonalization.Service.Infrastructure.Persistence.Configurations;

public class RutaAprendizajeConfiguration : IEntityTypeConfiguration<RutaAprendizaje>
{
    public void Configure(EntityTypeBuilder<RutaAprendizaje> builder)
    {
        builder.ToTable("rutas_aprendizaje");

        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.Property(e => e.Id).HasColumnName("idRutasAprendizaje");
        
        builder.Property(e => e.EstudianteId)
            .IsRequired()
            .HasMaxLength(12)
            .HasColumnName("idEstudiante");
            
        builder.Property(e => e.NombreRuta)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("nombre_ruta");
            
        builder.Property(e => e.EstadoRutaId).HasColumnName("idEstadosRuta");
        
        builder.Property(e => e.FechaCreacion)
            .HasColumnType("timestamp")
            .HasColumnName("fecha_creacion");
            
        builder.Property(e => e.FechaActualizacion)
            .HasColumnType("timestamp")
            .HasColumnName("fecha_actualizacion");
            
        builder.Property(e => e.EsActivo).HasColumnName("es_activo");

        builder.HasOne(d => d.EstadoRuta)
            .WithMany()
            .HasForeignKey(d => d.EstadoRutaId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("fk_rutas_aprendizaje_estados_ruta1");
            
        builder.HasIndex(e => e.EstadoRutaId, "fk_rutas_aprendizaje_estados_ruta1_idx");
    }
}
