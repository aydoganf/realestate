using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using REModel;
using REModel.Api;
using REModel.Api.Core;
using TestApi.Domain.Repositories;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdvertsController : Controller
    {
        private readonly IAdvertRepository _advertRepository;

        public AdvertsController(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Advert>>>> GetAllAdverts()
        {
            var adverts = await _advertRepository.GetAllAsync();

            return this.Build(adverts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Advert>>> GetAdvert(Guid id)
        {
            var advert = await _advertRepository.GetAdvertAsync(id);

            if (advert == null)
                return this.NotFound<Advert>();

            return this.Build(advert);
        }
    }
}
