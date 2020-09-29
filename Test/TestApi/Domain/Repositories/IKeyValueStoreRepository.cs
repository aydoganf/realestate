using REModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApi.Domain.Repositories
{
    public interface IKeyValueStoreRepository
    {
        Task<KeyValueStore> GetById(Guid id);
        Task<List<KeyValueStore>> GetByTypeAsync(string type);

        Task<List<KeyValueStore>> GetByTypeAndParentAsync(string type, string parent);

        Task<KeyValueStore> AddAsync(KeyValueStore obj);

        Task<KeyValueStore> UpdateAsync(KeyValueStore obj);

        Task DeleteAsync(Guid id);

        Task<KeyValueStore> GetBy(string type, string value);
    }
}
