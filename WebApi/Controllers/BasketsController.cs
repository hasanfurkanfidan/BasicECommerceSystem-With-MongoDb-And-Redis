using Business.Abstract;
using Entities.Dtos.BasketDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class BasketsController : BaseController
    {
        private readonly IBasketService _basketService;
        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(BasketCreateOrUpdateDto basketCreateOrUpdateDto)
        {
            return GetResponseOnlyResult(await _basketService.AddToBasket(basketCreateOrUpdateDto));
        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> GetBasket(string userName)
        {
            return GetResponseOnlyResultData(await _basketService.GetBasket(userName));
        }
    }
}
