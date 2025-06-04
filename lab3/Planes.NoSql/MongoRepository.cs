using MongoDB.Driver;
using Warships.Nosql.Models;

namespace Warships.Nosql
{
    public class MongoRepository : IRepositoryNosql
    {
        private readonly IMongoCollection<WarshipDocument> _collection;

        public MongoRepository(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            _collection = database.GetCollection<WarshipDocument>(collectionName);
        }

        public async Task<List<WarshipDocument>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        public async Task<WarshipDocument> GetByIdAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(WarshipDocument doc) =>
            await _collection.InsertOneAsync(doc);

        public async Task UpdateAsync(WarshipDocument doc) =>
            await _collection.ReplaceOneAsync(x => x.Id == doc.Id, doc);

        public async Task DeleteAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }
}
