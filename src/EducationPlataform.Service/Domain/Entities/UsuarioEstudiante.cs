using EducationPlataform.Service.Domain.Exceptions;

namespace EducationPlataform.Service.Domain.Entities;

public class UsuarioEstudiante
{
    public string EstudianteId { get; private set; } = string.Empty;
    public string Contrasena { get; private set; } = string.Empty;
    public DateTime FechaCreacion { get; private set; }
    public bool EsActivo { get; private set; }

    public virtual Estudiante? Estudiante { get; private set; }

    protected UsuarioEstudiante() { }

    public UsuarioEstudiante(string estudianteId, string contrasena)
    {
        if (string.IsNullOrWhiteSpace(estudianteId))
            throw new DomainException("El ID del estudiante no puede estar vacío.");

        if (string.IsNullOrWhiteSpace(contrasena))
            throw new DomainException("La contraseña no puede estar vacía.");

        EstudianteId = estudianteId;
        Contrasena = contrasena;
        FechaCreacion = DateTime.UtcNow;
        EsActivo = true;
    }
}
