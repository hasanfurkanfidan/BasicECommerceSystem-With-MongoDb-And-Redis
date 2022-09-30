using Core.Utils.Result.Abstract;
using Entities.Dtos.BasketDtos;

namespace Business.Abstract
{
    public interface IBasketService
    {
        Task<IResult> AddToBasket(BasketCreateOrUpdateDto basketCreateOrUpdateDto);
        Task<IDataResult<BasketDto>> GetBasket(string userName);
    }
}
