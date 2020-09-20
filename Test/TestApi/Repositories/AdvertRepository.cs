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
    public class AdvertRepository : IAdvertRepository
    {
        private readonly IMongoDatabase _mongoDatabase;
        public AdvertRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        private IMongoCollection<Advert> Collection => _mongoDatabase.GetCollection<Advert>("Adverts");

        public async Task<Advert> AddAsync(Advert advert)
        {
            await Collection.InsertOneAsync(advert);
            
            return advert;
        }

        public async Task<Advert> GetAdvertAsync(Guid id)
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Advert>> GetAllAsync()
        {
            return await Collection.AsQueryable().ToListAsync();
        }
    }
}
