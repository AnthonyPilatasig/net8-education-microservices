using MediatR;

namespace EducationPlataform.Service.Application.Commands;

public class InscribirEstudianteCommand : IRequest<bool>
{
    public string EstudianteId { get; set; } = string.Empty;
    public int CursoId { get; set; }
}
