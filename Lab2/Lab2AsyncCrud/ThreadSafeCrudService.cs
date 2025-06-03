using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

public class ThreadSafeCrudService<T> : ICrudServiceAsync<T> where T : class
{
    private readonly ConcurrentDictionary<Guid, T> _storage = new();
    private readonly Func<T, Guid> _getId;
    private readonly string _filePath;
    private readonly SemaphoreSlim _semaphore = new(1, 1);

    public ThreadSafeCrudService(Func<T, Guid> getId, string filePath)
    {
        _getId = getId;
        _filePath = filePath;
    }

    public async Task<bool> CreateAsync(T element)
    {
        var id = _getId(element);
        return _storage.TryAdd(id, element);
    }

    public async Task<T> ReadAsync(Guid id)
    {
        _storage.TryGetValue(id, out T value);
        return value;
    }

    public async Task<IEnumerable<T>> ReadAllAsync()
    {
        return _storage.Values.ToList();
    }

    public async Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
    {
        return _storage.Values.Skip((page - 1) * amount).Take(amount);
    }

    public async Task<bool> UpdateAsync(T element)
    {
        var id = _getId(element);
        _storage[id] = element;
        return true;
    }

    public async Task<bool> RemoveAsync(T element)
    {
        var id = _getId(element);
        return _storage.TryRemove(id, out _);
    }

    public async Task<bool> SaveAsync()
    {
        await _semaphore.WaitAsync();
        try
        {
            var json = JsonSerializer.Serialize(_storage.Values);
            await File.WriteAllTextAsync(_filePath, json);
            return true;
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public IEnumerator<T> GetEnumerator() => _storage.Values.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}