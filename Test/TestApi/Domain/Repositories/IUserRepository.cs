using REModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);

        Task<User> GetAsync(Guid id);

        Task<List<User>> GetAllAsync();
    }
}
