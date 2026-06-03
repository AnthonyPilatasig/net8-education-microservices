using ContentPersonalization.Service.Domain.Entities;

namespace ContentPersonalization.Service.Domain.Repositories;

public interface IRutaAprendizajeRepository
{
    Task<RutaAprendizaje?> ObtenerPorEstudianteIdAsync(string estudianteId, CancellationToken cancellationToken = default);
    Task AgregarAsync(RutaAprendizaje ruta, CancellationToken cancellationToken = default);
    Task ActualizarAsync(RutaAprendizaje ruta, CancellationToken cancellationToken = default);
}
