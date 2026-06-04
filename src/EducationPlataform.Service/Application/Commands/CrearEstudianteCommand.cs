using EducationPlataform.Service.Domain.Entities;
using EducationPlataform.Service.Infrastructure.Persistence;
using MediatR;

namespace EducationPlataform.Service.Application.Commands;

public record CrearEstudianteCommand(
    string Id,
    string CodigoEstudiante,
    string PrimerNombre,
    string PrimerApellido,
    string Email
) : IRequest<string>;

public class CrearEstudianteCommandHandler : IRequestHandler<CrearEstudianteCommand, string>
{
    private readonly EducationPlatformContext _context;

    public CrearEstudianteCommandHandler(EducationPlatformContext context)
    {
        _context = context;
    }

    public async Task<string> Handle(CrearEstudianteCommand request, CancellationToken cancellationToken)
    {
        var estudiante = new Estudiante(
            request.Id,
            request.CodigoEstudiante,
            request.PrimerNombre,
            request.PrimerApellido,
            request.Email
        );

        _context.Estudiantes.Add(estudiante);
        await _context.SaveChangesAsync(cancellationToken);

        return estudiante.Id;
    }
}
