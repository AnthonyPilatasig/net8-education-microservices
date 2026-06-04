using EducationPlataform.Service.Domain.Entities;
using EducationPlataform.Service.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EducationPlataform.Service.Application.Queries;

public record ObtenerCursoPorIdQuery(int Id) : IRequest<Curso?>;

public class ObtenerCursoPorIdQueryHandler : IRequestHandler<ObtenerCursoPorIdQuery, Curso?>
{
    private readonly EducationPlatformContext _context;

    public ObtenerCursoPorIdQueryHandler(EducationPlatformContext context)
    {
        _context = context;
    }

    public async Task<Curso?> Handle(ObtenerCursoPorIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Cursos
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
    }
}
