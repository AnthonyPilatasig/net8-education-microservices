using EducationPlataform.Service.Domain.Exceptions;

namespace EducationPlataform.Service.Domain.Entities;

public class Inscripcion
{
    public int Id { get; private set; }
    public string EstudianteId { get; private set; } = string.Empty;
    public int CursoId { get; private set; }
    public DateTime FechaInscripcion { get; private set; }
    public string EstadoInscripcion { get; private set; } = "ACTIVA";
    public decimal ProgresoPorcentaje { get; private set; } = 0.0m;
    public bool EsActivo { get; private set; }

    public virtual Estudiante? Estudiante { get; private set; }
    public virtual Curso? Curso { get; private set; }

    protected Inscripcion() { }

    public Inscripcion(string estudianteId, int cursoId)
    {
        if (string.IsNullOrWhiteSpace(estudianteId))
            throw new DomainException("El ID del estudiante no puede estar vacío.");

        EstudianteId = estudianteId;
        CursoId = cursoId;
        FechaInscripcion = DateTime.UtcNow;
        EstadoInscripcion = "ACTIVA";
        ProgresoPorcentaje = 0.0m;
        EsActivo = true;
    }

    public void ActualizarProgreso(decimal nuevoProgreso)
    {
        if (nuevoProgreso < 0 || nuevoProgreso > 100)
            throw new DomainException("El progreso debe estar entre 0 y 100.");

        ProgresoPorcentaje = nuevoProgreso;

        if (ProgresoPorcentaje >= 100)
        {
            EstadoInscripcion = "COMPLETADA";
        }
    }
}
