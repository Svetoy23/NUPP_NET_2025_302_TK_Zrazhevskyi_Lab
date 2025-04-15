namespace Library.Common;

public class InMemoryCrudService<T> : ICrudService<T> where T : class
{
    private readonly Dictionary<Guid, T> _storage = new();
    private readonly Func<T, Guid> _getId;

    public InMemoryCrudService(Func<T, Guid> getId)
    {
        _getId = getId;
    }

    public void Create(T element)
    {
        _storage[_getId(element)] = element;
        LibraryStats.IncrementItemCount();
    }

    public T Read(Guid id) => _storage[id];
    public IEnumerable<T> ReadAll() => _storage.Values;
    public void Update(T element) => _storage[_getId(element)] = element;
    public void Remove(T element) => _storage.Remove(_getId(element));
}