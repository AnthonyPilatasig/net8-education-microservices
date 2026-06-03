using Assessment.Service.Domain.Exceptions;

namespace Assessment.Service.Domain.Entities;

public class ResultadoEvaluacion
{
    public int Id { get; private set; }
    public string EstudianteId { get; private set; } = string.Empty;
    public int EvaluacionId { get; private set; }
    public decimal PuntajeObtenido { get; private set; }
    public decimal PuntajeMaximo { get; private set; }
    public int TiempoEmpleadoMinutos { get; private set; }
    public DateTime FechaCompletacion { get; private set; }
    public bool EsActivo { get; private set; }

    public virtual Evaluacion? Evaluacion { get; private set; }

    protected ResultadoEvaluacion() { }

    public ResultadoEvaluacion(string estudianteId, int evaluacionId, decimal puntajeObtenido, decimal puntajeMaximo, int tiempoEmpleadoMinutos)
    {
        if (string.IsNullOrWhiteSpace(estudianteId))
            throw new DomainException("El ID del estudiante no puede estar vacío.");

        if (puntajeObtenido < 0 || puntajeObtenido > puntajeMaximo)
            throw new DomainException("El puntaje obtenido es inválido.");

        EstudianteId = estudianteId;
        EvaluacionId = evaluacionId;
        PuntajeObtenido = puntajeObtenido;
        PuntajeMaximo = puntajeMaximo;
        TiempoEmpleadoMinutos = tiempoEmpleadoMinutos;
        FechaCompletacion = DateTime.UtcNow;
        EsActivo = true;
    }
}
