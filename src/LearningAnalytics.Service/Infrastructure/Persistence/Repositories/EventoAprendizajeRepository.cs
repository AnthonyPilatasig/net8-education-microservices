using LearningAnalytics.Service.Domain.Entities;
using LearningAnalytics.Service.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LearningAnalytics.Service.Infrastructure.Persistence.Repositories;

public class EventoAprendizajeRepository : IEventoAprendizajeRepository
{
    private readonly LearningAnalyticsContext _context;

    public EventoAprendizajeRepository(LearningAnalyticsContext context)
    {
        _context = context;
    }

    public async Task AgregarAsync(EventoAprendizaje evento, CancellationToken cancellationToken = default)
    {
        await _context.EventosAprendizaje.AddAsync(evento, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<EventoAprendizaje>> ObtenerPorEstudianteIdAsync(string estudianteId, CancellationToken cancellationToken = default)
    {
        return await _context.EventosAprendizaje
            .Include(e => e.TipoEvento)
            .Where(e => e.EstudianteId == estudianteId)
            .OrderByDescending(e => e.FechaEvento)
            .ToListAsync(cancellationToken);
    }
}
