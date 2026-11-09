using System.Text.Json;
using GimnasioController.Abstractions;

namespace GimnasioController
{
    /// <summary>
    /// Lee y guarda listas de objetos en archivos JSON.
    /// </summary>
    public class FileHandler<T> : IDataHandler<T>
    {
        public List<T> Load(string path)
        {
            try
            {
                if (!File.Exists(path))
                    return new List<T>();

                string json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            }
            catch (JsonException)
            {
                throw new InvalidDataException($"El archivo {path} tiene un formato incorrecto.");
            }
        }

        public void Save(string path, List<T> items)
        {
            string json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, json);
        }
    }
}