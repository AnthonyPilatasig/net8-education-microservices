using Assessment.Service.Domain.Exceptions;

namespace Assessment.Service.Domain.Entities;

public class Pregunta
{
    public int Id { get; private set; }
    public int EvaluacionId { get; private set; }
    public int TipoPreguntaId { get; private set; }
    public string TextoPregunta { get; private set; } = string.Empty;
    public string PreguntasJson { get; private set; } = string.Empty;
    public string RespuestaCorrecta { get; private set; } = string.Empty;
    public int OrdenPregunta { get; private set; }
    public bool EsActivo { get; private set; }

    public virtual Evaluacion? Evaluacion { get; private set; }
    public virtual TipoPregunta? TipoPregunta { get; private set; }

    protected Pregunta() { }

    public Pregunta(int evaluacionId, int tipoPreguntaId, string textoPregunta, string preguntasJson, string respuestaCorrecta, int ordenPregunta)
    {
        if (string.IsNullOrWhiteSpace(textoPregunta))
            throw new DomainException("El texto de la pregunta no puede estar vacío.");

        EvaluacionId = evaluacionId;
        TipoPreguntaId = tipoPreguntaId;
        TextoPregunta = textoPregunta;
        PreguntasJson = preguntasJson;
        RespuestaCorrecta = respuestaCorrecta;
        OrdenPregunta = ordenPregunta;
        EsActivo = true;
    }
}
