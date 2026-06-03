namespace CompetencyMapping.Service.Domain.Entities;

public class NivelPrioridad
{
    public int Id { get; private set; }
    public string NombrePrioridad { get; private set; } = string.Empty;
    public int ValorPrioridad { get; private set; }
    public bool EsActivo { get; private set; }

    protected NivelPrioridad() { }

    public NivelPrioridad(string nombrePrioridad, int valorPrioridad)
    {
        NombrePrioridad = nombrePrioridad;
        ValorPrioridad = valorPrioridad;
        EsActivo = true;
    }
}
