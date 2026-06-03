using MediatR;

namespace ContentPersonalization.Service.Application.Commands;

public class GenerarRutaAprendizajeCommand : IRequest<bool>
{
    public string EstudianteId { get; set; } = string.Empty;
    public string NombreRuta { get; set; } = string.Empty;
    public int EstadoRutaId { get; set; }
    public List<int> ContenidosIds { get; set; } = new();
}
