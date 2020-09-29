using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REModel;
using REModel.Api.Core;
using TestApi.Domain.Repositories;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KeyValueStoresController : Controller
    {
        private readonly IKeyValueStoreRepository _repository;

        public KeyValueStoresController(IKeyValueStoreRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<KeyValueStore>>> AddKeyValueStore([FromBody] KeyValueStore keyValueStore)
        {
            var added = await _repository.AddAsync(keyValueStore);

            return this.Build(added); 
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ApiResponse<KeyValueStore>>> UpdateKeyValueStore(Guid id, [FromBody] KeyValueStore keyValueStore)
        {
            keyValueStore.Id = id;

            var updated = await _repository.UpdateAsync(keyValueStore);

            return this.Build(updated);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<KeyValueStore>>> GetById(Guid id)
        {
            var store = await _repository.GetById(id);

            if (store == null)
                return this.NotFound<KeyValueStore>();

            return this.Build(store);
        }

        [HttpGet("{id}/parent")]
        public async Task<ActionResult<ApiResponse<KeyValueStore>>> GetParent(Guid id)
        {
            var store = await _repository.GetById(id);

            if (store == null)
                return this.NotFound<KeyValueStore>();

            var parent = await _repository.GetBy(store.Type, store.Parent);

            if (parent == null)
                return this.NotFound<KeyValueStore>();

            return this.Build(parent);
        }

        [HttpGet("type/{type}")]
        public async Task<ActionResult<ApiResponse<List<KeyValueStore>>>> GetByType(string type)
        {
            var keyValueStores = await _repository.GetByTypeAsync(type);

            return this.Build(keyValueStores);
        }

        [HttpGet("type/{type}/parent/{parent}")]
        public async Task<ActionResult<ApiResponse<List<KeyValueStore>>>> GetByTypeAndParent(string type, string parent)
        {
            var keyValueStores = await _repository.GetByTypeAndParentAsync(type, parent);

            return this.Build(keyValueStores);
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
