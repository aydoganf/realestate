using MongoDB.Driver;
using REModel;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Domain.Repositories;
using MongoDB.Driver.Linq;
using System.Collections.Generic;

namespace TestApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _mongoDatabase; 

        public UserRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        private IMongoCollection<User> Collection => _mongoDatabase.GetCollection<User>("Users");

        public async Task AddAsync(User user)
        {
            await Collection.InsertOneAsync(user);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await Collection.AsQueryable().ToListAsync();
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await Collection.AsQueryable().FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
