using REModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Domain.Repositories
{
    public interface IAdvertRepository
    {
        Task<Advert> AddAsync(Advert advert);
        Task<Advert> GetAdvertAsync(Guid id);
        Task<List<Advert>> GetAllAsync();
    }
}
