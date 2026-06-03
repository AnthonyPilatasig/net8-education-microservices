using MediatR;

namespace AdaptiveEngine.Service.Application.Commands;

public class ActualizarNivelAprendizajeCommand : IRequest<bool>
{
    public string EstudianteId { get; set; } = string.Empty;
    public decimal PuntuacionRendimiento { get; set; }
}
