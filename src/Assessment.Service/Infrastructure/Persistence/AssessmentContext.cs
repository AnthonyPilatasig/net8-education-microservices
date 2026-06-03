using Assessment.Service.Domain.Entities;
using Assessment.Service.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Service.Infrastructure.Persistence;

public class AssessmentContext : DbContext
{
    public AssessmentContext(DbContextOptions<AssessmentContext> options)
        : base(options)
    {
    }

    public DbSet<Evaluacion> Evaluaciones { get; set; } = null!;
    public DbSet<Pregunta> Preguntas { get; set; } = null!;
    public DbSet<ResultadoEvaluacion> ResultadosEvaluacion { get; set; } = null!;
    public DbSet<TipoEvaluacion> TiposEvaluacion { get; set; } = null!;
    public DbSet<TipoPregunta> TiposPregunta { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.ApplyConfiguration(new EvaluacionConfiguration());
        modelBuilder.ApplyConfiguration(new PreguntaConfiguration());
        modelBuilder.ApplyConfiguration(new ResultadoEvaluacionConfiguration());
        modelBuilder.ApplyConfiguration(new TipoEvaluacionConfiguration());
        modelBuilder.ApplyConfiguration(new TipoPreguntaConfiguration());
    }
}
