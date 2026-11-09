namespace GimnasioModels;

/// <summary>
/// Usuario que utiliza la aplicación del gimnasio.
/// </summary>
public class UsuarioBasico : Persona
{
    private double _peso;
    private double _estatura;

    /// <summary>Nombre de usuario para iniciar sesión.</summary>
    public string NombreUsuario { get; set; } = string.Empty;

    /// <summary>Peso en kilogramos (debe ser mayor que cero).</summary>
    public double Peso
    {
        get => _peso;
        set
        {
            if (value <= 0) throw new ArgumentException("El peso debe ser mayor que cero.");
            _peso = value;
        }
    }

    /// <summary>Estatura en metros (debe ser mayor que cero).</summary>
    public double Estatura
    {
        get => _estatura;
        set
        {
            if (value <= 0) throw new ArgumentException("La estatura debe ser mayor que cero.");
            _estatura = value;
        }
    }

    /// <summary>Índice de masa corporal, calculado con peso y estatura.</summary>
    public double IMC => _estatura > 0 ? Math.Round(_peso / (_estatura * _estatura), 2) : 0;

    /// <summary>Rutinas del usuario.</summary>
    public List<Rutina> Rutinas { get; set; } = new();

    public override string ObtenerRol() => "Usuario";
}