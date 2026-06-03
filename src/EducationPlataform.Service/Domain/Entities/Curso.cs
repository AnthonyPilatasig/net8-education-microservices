using EducationPlataform.Service.Domain.Exceptions;

namespace EducationPlataform.Service.Domain.Entities;

public class Curso
{
    public int Id { get; private set; }
    public string CodigoCurso { get; private set; } = string.Empty;
    public string NombreCurso { get; private set; } = string.Empty;
    public string Descripcion { get; private set; } = string.Empty;
    public decimal DuracionHoras { get; private set; }
    public string NivelDificultad { get; private set; } = string.Empty;
    public string Categoria { get; private set; } = string.Empty;
    public bool EsActivo { get; private set; }

    protected Curso() { }

    public Curso(string codigoCurso, string nombreCurso, decimal duracionHoras, string nivelDificultad)
    {
        if (string.IsNullOrWhiteSpace(codigoCurso))
            throw new DomainException("El código del curso no puede estar vacío.");

        CodigoCurso = codigoCurso;
        NombreCurso = nombreCurso;
        DuracionHoras = duracionHoras;
        NivelDificultad = nivelDificultad;
        EsActivo = true;
    }
}
