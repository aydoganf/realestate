using MongoDB.Driver;
using REModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Domain.Repositories;
using MongoDB.Driver.Linq;

namespace TestApi.Repositories
{
    public class KeyValueStoreRepository : IKeyValueStoreRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public KeyValueStoreRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        private IMongoCollection<KeyValueStore> Collection =>
            _mongoDatabase.GetCollection<KeyValueStore>("KeyValueStore");

        public async Task<KeyValueStore> AddAsync(KeyValueStore obj)
        {
            await Collection.InsertOneAsync(obj);

            return obj;
        }

        public async Task DeleteAsync(Guid id)
        {
            var filter = Builders<KeyValueStore>.Filter.Eq(k => k.Id, id);

            await Collection.DeleteOneAsync(filter);
        }

        public async Task<KeyValueStore> GetBy(string type, string value)
        {
            return await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(k => k.Type == type && k.Value == value);
        }

        public async Task<KeyValueStore> GetById(Guid id)
        {
            return await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(k => k.Id == id);
        }

        public async Task<List<KeyValueStore>> GetByTypeAndParentAsync(string type, string parent)
        {
            return await Collection
                .AsQueryable()
                .Where(k => k.Type == type && k.Parent == parent)
                .ToListAsync();
        }

        public async Task<List<KeyValueStore>> GetByTypeAsync(string type)
        {
            return await Collection
                .AsQueryable()
                .Where(k => k.Type == type)
                .ToListAsync();
        }

        public async Task<KeyValueStore> UpdateAsync(KeyValueStore obj)
        {
            var filter = Builders<KeyValueStore>.Filter.Eq(k => k.Id, obj.Id);
            var update = Builders<KeyValueStore>.Update
                .Set(k => k.Key, obj.Key)
                .Set(k => k.Value, obj.Value);

            var result = await Collection.UpdateOneAsync(filter, update);
            
            return await Task.FromResult(obj);
        }
    }
}
