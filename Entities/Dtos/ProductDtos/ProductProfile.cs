using AutoMapper;
using Entities.Concrete;

namespace Entities.Dtos.ProductDtos
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductCreateDto, Product>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
