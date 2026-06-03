using Assessment.Service.Domain.Exceptions;

namespace Assessment.Service.Domain.Entities;

public class Evaluacion
{
    public int Id { get; private set; }
    public string CodigoEvaluacion { get; private set; } = string.Empty;
    public string Titulo { get; private set; } = string.Empty;
    public int TipoEvaluacionId { get; private set; }
    public int NivelesDificultadId { get; private set; }
    public int TiempoEstimadoMinutos { get; private set; }
    public bool EsActivo { get; private set; }

    public virtual TipoEvaluacion? TipoEvaluacion { get; private set; }

    private readonly List<Pregunta> _preguntas = new();
    public virtual IReadOnlyCollection<Pregunta> Preguntas => _preguntas.AsReadOnly();

    private readonly List<ResultadoEvaluacion> _resultadosEvaluacion = new();
    public virtual IReadOnlyCollection<ResultadoEvaluacion> ResultadosEvaluacion => _resultadosEvaluacion.AsReadOnly();

    protected Evaluacion() { }

    public Evaluacion(string codigoEvaluacion, string titulo, int tipoEvaluacionId, int nivelesDificultadId, int tiempoEstimadoMinutos)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            throw new DomainException("El título de la evaluación no puede estar vacío.");
            
        CodigoEvaluacion = codigoEvaluacion;
        Titulo = titulo;
        TipoEvaluacionId = tipoEvaluacionId;
        NivelesDificultadId = nivelesDificultadId;
        TiempoEstimadoMinutos = tiempoEstimadoMinutos;
        EsActivo = true;
    }
}
