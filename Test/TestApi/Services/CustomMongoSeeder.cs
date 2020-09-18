using MongoDB.Driver;
using REModel;
using REModel.DatabaseConnection.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Domain.Repositories;

namespace TestApi.Services
{
    public class CustomMongoSeeder : MongoSeeder
    {
        private readonly IUserRepository _userRepository;

        public CustomMongoSeeder(
            IMongoDatabase database,
            IUserRepository userRepository) : base(database)
        {
            _userRepository = userRepository;
        }

        protected override async Task CustomSeedAsync()
        {
            var user = new User
            {
                AccountType = "admin",
                Address = "",
                Deleted = false,
                Email = "aydoganf@itu.edu.tr",
                Id = Guid.NewGuid(),
                IsActive = true,
                Name = "Faruk",
                PasswordHash = "passwordhash",
                PasswordSalt = "passwordsalt",
                Phone = "",
                Surname = "Aydogan"
            };

            await _userRepository.AddAsync(user);
        }
    }
}
