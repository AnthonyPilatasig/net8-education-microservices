using EducationPlataform.Service.Domain.Entities;
using EducationPlataform.Service.Infrastructure.Persistence;
using MediatR;

namespace EducationPlataform.Service.Application.Commands;

public record CrearCursoCommand(
    string CodigoCurso,
    string NombreCurso,
    decimal DuracionHoras,
    string NivelDificultad
) : IRequest<int>;

public class CrearCursoCommandHandler : IRequestHandler<CrearCursoCommand, int>
{
    private readonly EducationPlatformContext _context;

    public CrearCursoCommandHandler(EducationPlatformContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CrearCursoCommand request, CancellationToken cancellationToken)
    {
        var curso = new Curso(
            request.CodigoCurso,
            request.NombreCurso,
            request.DuracionHoras,
            request.NivelDificultad
        );

        _context.Cursos.Add(curso);
        await _context.SaveChangesAsync(cancellationToken);

        return curso.Id; // El ID lo genera la base de datos (Autoincremental)
    }
}
