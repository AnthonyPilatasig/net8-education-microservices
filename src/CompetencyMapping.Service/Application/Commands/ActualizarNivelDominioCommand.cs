using MediatR;

namespace CompetencyMapping.Service.Application.Commands;

public class ActualizarNivelDominioCommand : IRequest<bool>
{
    public string EstudianteId { get; set; } = string.Empty;
    public int CompetenciaId { get; set; }
    public decimal NivelDominio { get; set; }
    public int EstadoDominioId { get; set; }
    public decimal Confianza { get; set; }
}
