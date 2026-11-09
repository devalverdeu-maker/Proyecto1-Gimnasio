namespace GimnasioModels;

/// <summary>
/// Clase base de las personas del sistema (usuarios y entrenadores).
/// </summary>
public abstract class Persona
{
    /// <summary>Identificador de la persona.</summary>
    public int Id { get; set; }

    /// <summary>Nombre completo.</summary>
    public string Nombre { get; set; } = string.Empty;

    /// <summary>Edad en años.</summary>
    public int Edad { get; set; }

    /// <summary>Indica el rol de la persona en el sistema.</summary>
    public abstract string ObtenerRol();

    /// <summary>Texto que representa a la persona.</summary>
    public override string ToString() => $"{Id} - {Nombre} ({ObtenerRol()})";
}