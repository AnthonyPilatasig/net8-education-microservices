using Assessment.Service.Domain.Entities;
using Assessment.Service.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Service.Application.Queries;

public record ObtenerEvaluacionesQuery() : IRequest<List<Evaluacion>>;

public class ObtenerEvaluacionesQueryHandler : IRequestHandler<ObtenerEvaluacionesQuery, List<Evaluacion>>
{
    private readonly AssessmentContext _context;

    public ObtenerEvaluacionesQueryHandler(AssessmentContext context)
    {
        _context = context;
    }

    public async Task<List<Evaluacion>> Handle(ObtenerEvaluacionesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Evaluaciones
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}
