using EducationPlataform.Service.Domain.Entities;
using EducationPlataform.Service.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EducationPlataform.Service.Infrastructure.Persistence;

public class EducationPlatformContext : DbContext
{
    public EducationPlatformContext(DbContextOptions<EducationPlatformContext> options)
        : base(options)
    {
    }

    public DbSet<Curso> Cursos { get; set; } = null!;
    public DbSet<Estudiante> Estudiantes { get; set; } = null!;
    public DbSet<Inscripcion> Inscripciones { get; set; } = null!;
    public DbSet<UsuarioEstudiante> UsuariosEstudiantes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.ApplyConfiguration(new CursoConfiguration());
        modelBuilder.ApplyConfiguration(new EstudianteConfiguration());
        modelBuilder.ApplyConfiguration(new InscripcionConfiguration());
        modelBuilder.ApplyConfiguration(new UsuarioEstudianteConfiguration());
    }
}
