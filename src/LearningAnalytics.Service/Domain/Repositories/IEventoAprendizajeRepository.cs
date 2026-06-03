using LearningAnalytics.Service.Domain.Entities;

namespace LearningAnalytics.Service.Domain.Repositories;

public interface IEventoAprendizajeRepository
{
    Task AgregarAsync(EventoAprendizaje evento, CancellationToken cancellationToken = default);
    Task<IEnumerable<EventoAprendizaje>> ObtenerPorEstudianteIdAsync(string estudianteId, CancellationToken cancellationToken = default);
}
