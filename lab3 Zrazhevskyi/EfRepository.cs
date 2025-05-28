using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airport.Infrastructure
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly AirportContext _context;
        private readonly DbSet<T> _dbSet;

        public EfRepository(AirportContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public Task Update(T entity) { _dbSet.Update(entity); return Task.CompletedTask; }
        public Task Delete(T entity) { _dbSet.Remove(entity); return Task.CompletedTask; }
    }
}