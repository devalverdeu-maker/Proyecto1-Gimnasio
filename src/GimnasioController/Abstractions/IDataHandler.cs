namespace GimnasioController.Abstractions
{
    /// <summary>
    /// Contrato para leer y guardar datos sin depender de dónde se almacenen.
    /// </summary>
    public interface IDataHandler<T>
    {
        List<T> Load(string path);
        void Save(string path, List<T> items);
    }
}