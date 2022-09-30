using Core.Utils.Result.Abstract;
using Entities.Dtos.ProductDtos;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<IDataResult<List<ProductDto>>> GetAllProducts();
        Task<IDataResult<ProductDto>> GetProductById(string id);
        Task<IResult> CreateProduct(ProductCreateDto product);
        Task<IResult> UpdateProduct(ProductUpdateDto product);
        Task<IResult>DeleteProduct(string id);
    }
}
