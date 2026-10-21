using System.Text.Json;

namespace UniversityManagement.Common;

public class CrudService<T> : ICrudService<T> where T : class, IEntity
{
    private Dictionary<Guid, T> _items = new();

    public void Create(T element)
    {
        ArgumentNullException.ThrowIfNull(element);
        if (element.Id == Guid.Empty)
            element.Id = Guid.NewGuid();

        if (!_items.TryAdd(element.Id, element))
            throw new InvalidOperationException($"Елемент з ID {element.Id} вже існує.");
    }

    public T? Read(Guid id) => _items.GetValueOrDefault(id);

    public IEnumerable<T> ReadAll() => _items.Values.ToList();

    public void Update(T element)
    {
        ArgumentNullException.ThrowIfNull(element);
        if (!_items.ContainsKey(element.Id))
            throw new KeyNotFoundException($"Елемент з ID {element.Id} не знайдено.");

        _items[element.Id] = element;
    }

    public void Remove(T element)
    {
        ArgumentNullException.ThrowIfNull(element);
        _items.Remove(element.Id);
    }

    // Додаткове завдання: серіалізація даних у JSON
    public void Save(string filePath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);
        string? directory = Path.GetDirectoryName(Path.GetFullPath(filePath));
        if (!string.IsNullOrEmpty(directory))
            Directory.CreateDirectory(directory);

        var options = new JsonSerializerOptions { WriteIndented = true };
        File.WriteAllText(filePath, JsonSerializer.Serialize(_items.Values, options));
    }

    // Додаткове завдання: завантаження даних із JSON
    public void Load(string filePath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);
        if (!File.Exists(filePath))
            throw new FileNotFoundException("Файл даних не знайдено.", filePath);

        var loaded = JsonSerializer.Deserialize<List<T>>(File.ReadAllText(filePath));
        _items = (loaded ?? new List<T>())
            .Where(item => item is not null)
            .GroupBy(item => item.Id)
            .Select(group => group.First())
            .ToDictionary(item => item.Id);
    }
}
