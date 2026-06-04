using LearningAnalytics.Service.Domain.Entities;
using LearningAnalytics.Service.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LearningAnalytics.Service.Application.Queries;

public record ObtenerMetricasPorEstudianteQuery(string EstudianteId) : IRequest<MetricaCompromiso?>;

public class ObtenerMetricasPorEstudianteQueryHandler : IRequestHandler<ObtenerMetricasPorEstudianteQuery, MetricaCompromiso?>
{
    private readonly LearningAnalyticsContext _context;

    public ObtenerMetricasPorEstudianteQueryHandler(LearningAnalyticsContext context)
    {
        _context = context;
    }

    public async Task<MetricaCompromiso?> Handle(ObtenerMetricasPorEstudianteQuery request, CancellationToken cancellationToken)
    {
        return await _context.MetricasCompromiso
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.EstudianteId == request.EstudianteId, cancellationToken);
    }
}
