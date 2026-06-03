using MediatR;

namespace Assessment.Service.Application.Commands;

public class RegistrarResultadoEvaluacionCommand : IRequest<bool>
{
    public string EstudianteId { get; set; } = string.Empty;
    public int EvaluacionId { get; set; }
    public decimal PuntajeObtenido { get; set; }
    public decimal PuntajeMaximo { get; set; }
    public int TiempoEmpleadoMinutos { get; set; }
}
