using ContentPersonalization.Service.Domain.Exceptions;

namespace ContentPersonalization.Service.Domain.Entities;

public class ContenidoEducativo
{
    public int Id { get; private set; }
    public string CodigoContenido { get; private set; } = string.Empty;
    public string Titulo { get; private set; } = string.Empty;
    public int TipoContenidoId { get; private set; }
    public int NivelDificultadId { get; private set; }
    public int DuracionMinutos { get; private set; }
    public string UrlRecurso { get; private set; } = string.Empty;
    public string EtiquetasJson { get; private set; } = string.Empty;
    public bool EsActivo { get; private set; }

    public virtual NivelDificultad? NivelDificultad { get; private set; }
    public virtual TipoContenido? TipoContenido { get; private set; }

    protected ContenidoEducativo() { }

    public ContenidoEducativo(string codigoContenido, string titulo, int tipoContenidoId, int nivelDificultadId, int duracionMinutos, string urlRecurso)
    {
        if (string.IsNullOrWhiteSpace(codigoContenido))
            throw new DomainException("El código del contenido no puede estar vacío.");

        CodigoContenido = codigoContenido;
        Titulo = titulo;
        TipoContenidoId = tipoContenidoId;
        NivelDificultadId = nivelDificultadId;
        DuracionMinutos = duracionMinutos;
        UrlRecurso = urlRecurso;
        EsActivo = true;
    }
}
