using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utils.Result.Abstract;
using Core.Utils.Result.Concrete;
using DataAccess.Abstract.Mongo;
using DataAccess.Abstract.Redis;
using Entities.Concrete;
using Entities.Dtos.BasketDtos;
using Microsoft.VisualBasic;

namespace Business.Concrete
{
    public class BasketService : IBasketService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public BasketService(IProductRepository productRepository, IBasketRepository basketRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _basketRepository = basketRepository;
            _mapper = mapper;
        }
        public async Task<IResult> AddToBasket(BasketCreateOrUpdateDto basketCreateOrUpdateDto)
        {
            if (basketCreateOrUpdateDto == null)
                return new ErrorResult(Messages.InvalidParameter);

            if (basketCreateOrUpdateDto.Count < 1)
                return new ErrorResult(Messages.InValidCount);

            var existProduct = await _productRepository.GetById(basketCreateOrUpdateDto.ProductId);
            if (existProduct == null)
                return new ErrorResult(Messages.DataNotFound);

            var existBasket = await _basketRepository.Get(basketCreateOrUpdateDto.UserName);
            if (existBasket == null)
                existBasket = new Basket();

            existBasket.UserName = basketCreateOrUpdateDto.UserName;

            var basketItem = existBasket.BasketItems.FirstOrDefault(p => p.ProductId == basketCreateOrUpdateDto.ProductId);
            if (basketItem == null)
            {
                basketItem = new BasketItem();
                existBasket.BasketItems.Add(basketItem);
                basketItem.ProductId = basketCreateOrUpdateDto.ProductId;
                basketItem.Price = existProduct.Price;
                basketItem.Count = basketCreateOrUpdateDto.Count;
                basketItem.ProductName = existProduct.Name;
            }
            else
            {
                if (basketCreateOrUpdateDto.IsAdded)
                {
                    basketItem.Count += basketCreateOrUpdateDto.Count;
                }
                else
                {
                    if (basketCreateOrUpdateDto.Count > basketItem.Count)
                    {
                        basketItem.Count = 0;
                    }

                    basketItem.Count -= basketCreateOrUpdateDto.Count;
                }
            }

            await _basketRepository.SaveOrUpdate(existBasket, basketCreateOrUpdateDto.UserName);

            return new SuccessResult();
        }
        public async Task<IDataResult<BasketDto>> GetBasket(string userName)
        {
            var existBasket = await _basketRepository.Get(userName);
            if (existBasket == null)
                return new ErrorDataResult<BasketDto>(Messages.DataNotFound);

            var mappedBasket = _mapper.Map<BasketDto>(existBasket);

            return new SuccessDataResult<BasketDto>(mappedBasket);
        }
    }
}
