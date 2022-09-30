using AutoMapper;
using Entities.Concrete;

namespace Entities.Dtos.BasketDtos
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, BasketDto>().ForMember(dst => dst.Price, opt => opt.MapFrom(src => src.BasketItems.Sum(p => p.Count * p.Price)));

            CreateMap<BasketItem, BasketItemDto>();
        }
    }
}
