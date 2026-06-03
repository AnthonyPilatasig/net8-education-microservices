using AdaptiveEngine.Service.Domain.Entities;

namespace AdaptiveEngine.Service.Domain.Repositories;

public interface IPerfilEstudianteRepository
{
    Task<PerfilEstudiante?> ObtenerPorIdAsync(int id, CancellationToken cancellationToken = default);
    Task<PerfilEstudiante?> ObtenerPorEstudianteIdAsync(string estudianteId, CancellationToken cancellationToken = default);
    Task AgregarAsync(PerfilEstudiante perfil, CancellationToken cancellationToken = default);
    Task ActualizarAsync(PerfilEstudiante perfil, CancellationToken cancellationToken = default);
}
