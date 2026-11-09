namespace GimnasioModels;

/// <summary>
/// Entrenador personal o del gimnasio.
/// </summary>
public class Entrenador : Persona
{
    /// <summary>Tipo de entrenador: "Personal" o "Gimnasio".</summary>
    public string Tipo { get; set; } = "Gimnasio";

    public override string ObtenerRol() => $"Entrenador {Tipo}";
}