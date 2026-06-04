using Assessment.Service.Domain.Entities;
using Assessment.Service.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Service.Application.Queries;

public record ObtenerEvaluacionPorIdQuery(int Id) : IRequest<Evaluacion?>;

public class ObtenerEvaluacionPorIdQueryHandler : IRequestHandler<ObtenerEvaluacionPorIdQuery, Evaluacion?>
{
    private readonly AssessmentContext _context;

    public ObtenerEvaluacionPorIdQueryHandler(AssessmentContext context)
    {
        _context = context;
    }

    public async Task<Evaluacion?> Handle(ObtenerEvaluacionPorIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Evaluaciones
            .Include(e => e.Preguntas)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
    }
}
