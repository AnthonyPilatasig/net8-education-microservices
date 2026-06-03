using EducationPlataform.Service.Domain.Entities;

namespace EducationPlataform.Service.Domain.Repositories;

public interface IInscripcionRepository
{
    Task<Inscripcion?> ObtenerPorEstudianteYCursoAsync(string estudianteId, int cursoId, CancellationToken cancellationToken = default);
    Task AgregarAsync(Inscripcion inscripcion, CancellationToken cancellationToken = default);
    Task ActualizarAsync(Inscripcion inscripcion, CancellationToken cancellationToken = default);
}
