using GimnasioController.Abstractions;
using GimnasioModels;

namespace GimnasioController;

/// <summary>
/// Controla el registro y la consulta de usuarios.
/// </summary>
public class UsuarioController
{
    private readonly IDataHandler<UsuarioBasico> _dataHandler;
    private readonly string _ruta;

    public UsuarioController(IDataHandler<UsuarioBasico> dataHandler, string ruta)
    {
        _dataHandler = dataHandler;
        _ruta = ruta;
    }

    /// <summary>Devuelve todos los usuarios guardados.</summary>
    public List<UsuarioBasico> ObtenerUsuarios() => _dataHandler.Load(_ruta);

    /// <summary>Registra un usuario nuevo si su nombre de usuario no existe.</summary>
    public void Registrar(UsuarioBasico nuevo)
    {
        if (string.IsNullOrWhiteSpace(nuevo.NombreUsuario))
            throw new ArgumentException("El nombre de usuario es obligatorio.");

        List<UsuarioBasico> usuarios = ObtenerUsuarios();

        if (usuarios.Any(u => u.NombreUsuario.Equals(nuevo.NombreUsuario, StringComparison.OrdinalIgnoreCase)))
            throw new InvalidOperationException("Ese nombre de usuario ya existe.");

        nuevo.Id = usuarios.Count == 0 ? 1 : usuarios.Max(u => u.Id) + 1;
        usuarios.Add(nuevo);
        _dataHandler.Save(_ruta, usuarios);
    }
}