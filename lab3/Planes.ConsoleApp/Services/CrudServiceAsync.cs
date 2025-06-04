using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warships.ConsoleApp.Interfaces;

namespace Warships.ConsoleApp.Services
{
    public class CrudServiceAsync<T> : ICrudServiceAsync<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public CrudServiceAsync(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(T element)
        {
            await _repository.AddAsync(element);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<T?> ReadAsync(Guid id)
        {
            var result = await _repository.GetAllAsync();
            return result.FirstOrDefault(e => (e as dynamic).Id.ToString() == id.ToString());
        }

        public async Task<IEnumerable<T>> ReadAllAsync() => await _repository.GetAllAsync();

        public async Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
        {
            var data = await _repository.GetAllAsync();
            return data.Skip((page - 1) * amount).Take(amount);
        }

        public async Task<bool> RemoveAsync(T element)
        {
            await _repository.Delete(element);
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> SaveAsync()
        {
            await _repository.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(T element)
        {
            await _repository.Update(element);
            await _repository.SaveAsync();
            return true;
        }
    }
}
