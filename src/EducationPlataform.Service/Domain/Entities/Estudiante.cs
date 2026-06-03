using EducationPlataform.Service.Domain.Exceptions;

namespace EducationPlataform.Service.Domain.Entities;

public class Estudiante
{
    public string Id { get; private set; } = string.Empty;
    public string CodigoEstudiante { get; private set; } = string.Empty;
    public string PrimerNombre { get; private set; } = string.Empty;
    public string SegundoNombre { get; private set; } = string.Empty;
    public string PrimerApellido { get; private set; } = string.Empty;
    public string SegundoApellido { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public DateTime FechaRegistro { get; private set; }
    public bool EsActivo { get; private set; }

    public virtual UsuarioEstudiante? UsuarioEstudiante { get; private set; }
    
    private readonly List<Inscripcion> _inscripciones = new();
    public virtual IReadOnlyCollection<Inscripcion> Inscripciones => _inscripciones.AsReadOnly();

    protected Estudiante() { }

    public Estudiante(string id, string codigoEstudiante, string primerNombre, string primerApellido, string email)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new DomainException("El ID del estudiante no puede estar vacío.");

        if (string.IsNullOrWhiteSpace(email))
            throw new DomainException("El email del estudiante no puede estar vacío.");

        Id = id;
        CodigoEstudiante = codigoEstudiante;
        PrimerNombre = primerNombre;
        PrimerApellido = primerApellido;
        Email = email;
        FechaRegistro = DateTime.UtcNow;
        EsActivo = true;
    }

    public void AgregarInscripcion(Inscripcion inscripcion)
    {
        _inscripciones.Add(inscripcion);
    }
}
