namespace GimnasioModels;

/// <summary>
/// Rutina de ejercicios asignada a un usuario.
/// </summary>
public class Rutina
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public DateTime FechaInicio { get; set; }
    public DateTime FechaVencimiento { get; set; }

    /// <summary>Indica si la rutina ya venció.</summary>
    public bool EstaVencida => DateTime.Today > FechaVencimiento;
}