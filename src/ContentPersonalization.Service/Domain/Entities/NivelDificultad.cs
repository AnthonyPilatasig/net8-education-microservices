namespace ContentPersonalization.Service.Domain.Entities;

public class NivelDificultad
{
    public int Id { get; private set; }
    public string NombreNivel { get; private set; } = string.Empty;
    public decimal ValorMinimo { get; private set; }
    public decimal ValorMaximo { get; private set; }
    public bool EsActivo { get; private set; }

    protected NivelDificultad() { }

    public NivelDificultad(string nombreNivel, decimal valorMinimo, decimal valorMaximo)
    {
        NombreNivel = nombreNivel;
        ValorMinimo = valorMinimo;
        ValorMaximo = valorMaximo;
        EsActivo = true;
    }
}
