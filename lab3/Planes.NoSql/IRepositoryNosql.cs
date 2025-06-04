using Warships.Nosql.Models;

namespace Warships.Nosql
{
    public interface IRepositoryNosql
    {
        Task<List<WarshipDocument>> GetAllAsync();
        Task<WarshipDocument> GetByIdAsync(string id);
        Task CreateAsync(WarshipDocument doc);
        Task UpdateAsync(WarshipDocument doc);
        Task DeleteAsync(string id);
    }
}
