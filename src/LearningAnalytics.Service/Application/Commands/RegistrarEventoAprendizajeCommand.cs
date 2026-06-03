using MediatR;

namespace LearningAnalytics.Service.Application.Commands;

public class RegistrarEventoAprendizajeCommand : IRequest<bool>
{
    public string EstudianteId { get; set; } = string.Empty;
    public int ContenidoId { get; set; }
    public int TipoEventoId { get; set; }
    public string MetadatosJson { get; set; } = "{}";
}
