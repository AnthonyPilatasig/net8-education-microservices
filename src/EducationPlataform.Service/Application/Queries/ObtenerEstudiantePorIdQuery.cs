using EducationPlataform.Service.Domain.Entities;
using EducationPlataform.Service.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EducationPlataform.Service.Application.Queries;

public record ObtenerEstudiantePorIdQuery(string Id) : IRequest<Estudiante?>;

public class ObtenerEstudiantePorIdQueryHandler : IRequestHandler<ObtenerEstudiantePorIdQuery, Estudiante?>
{
    private readonly EducationPlatformContext _context;

    public ObtenerEstudiantePorIdQueryHandler(EducationPlatformContext context)
    {
        _context = context;
    }

    public async Task<Estudiante?> Handle(ObtenerEstudiantePorIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Estudiantes
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
    }
}
