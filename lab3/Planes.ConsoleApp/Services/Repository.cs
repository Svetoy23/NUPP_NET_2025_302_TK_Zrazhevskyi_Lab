using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Warships.ConsoleApp.Interfaces;
using Warships.Infrastructure;

namespace Warships.ConsoleApp.Services
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly WarshipContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(WarshipContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await Task.CompletedTask;
        }
    }
}