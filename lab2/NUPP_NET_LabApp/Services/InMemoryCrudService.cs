using NUPP_NET_LabApp.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace NUPP_NET_LabApp.Services
{
    public class InMemoryCrudService<T> : ICrudServiceAsync<T>
    {
        private readonly ConcurrentDictionary<Guid, T> _collection = new ConcurrentDictionary<Guid, T>();

        public async Task<bool> CreateAsync(T element)
        {
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null)
            {
                var id = (Guid)idProperty.GetValue(element);
                return _collection.TryAdd(id, element);
            }
            return false;
        }

        public async Task<T> ReadAsync(Guid id)
        {
            _collection.TryGetValue(id, out var element);
            return element;
        }

        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            return _collection.Values;
        }

        public async Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
        {
            return _collection.Values.Skip((page - 1) * amount).Take(amount);
        }

        public async Task<bool> UpdateAsync(T element)
        {
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null)
            {
                var id = (Guid)idProperty.GetValue(element);
                return _collection.TryUpdate(id, element, _collection[id]);
            }
            return false;
        }

        public async Task<bool> RemoveAsync(T element)
        {
            var idProperty = typeof(T).GetProperty("Id");
            if (idProperty != null)
            {
                var id = (Guid)idProperty.GetValue(element);
                return _collection.TryRemove(id, out _);
            }
            return false;
        }

        public async Task<bool> SaveAsync()
        {
            var json = JsonSerializer.Serialize(_collection.Values);
            await File.WriteAllTextAsync(FilePath, json);
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _collection.Values.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _collection.Values.GetEnumerator();
        }
    }
}
