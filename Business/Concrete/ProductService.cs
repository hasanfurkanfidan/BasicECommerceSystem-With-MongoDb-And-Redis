using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Utils.Result.Abstract;
using Core.Utils.Result.Concrete;
using DataAccess.Abstract.Mongo;
using Entities.Concrete;
using Entities.Dtos.ProductDtos;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateProduct(ProductCreateDto product)
        {
            if (product == null)
                return new ErrorResult(Messages.InvalidParameter);

            var mappedProduct = _mapper.Map<Product>(product);

            await _productRepository.Create(mappedProduct);

            return new SuccessResult();
        }

        public async Task<IResult> DeleteProduct(string id)
        {
            if (string.IsNullOrEmpty(id))
                return new ErrorResult(Messages.DataNotFound);

            var product = await _productRepository.GetById(id);
            await _productRepository.Delete(product);

            return new SuccessResult();
        }

        public async Task<IDataResult<List<ProductDto>>> GetAllProducts()
        {
            var products = await _productRepository.GetAll();
            var mappedProducts = _mapper.Map<List<ProductDto>>(products);

            return new SuccessDataResult<List<ProductDto>>(mappedProducts);
        }

        public async Task<IDataResult<ProductDto>> GetProductById(string id)
        {
            var product =await _productRepository.GetById(id);
            var mappedProduct = _mapper.Map<ProductDto>(product);

            return new SuccessDataResult<ProductDto>(mappedProduct);
        }
        public async Task<IResult>UpdateProduct(ProductUpdateDto productUpdateDto)
        {
            if (productUpdateDto == null)
                return new ErrorResult(Messages.InvalidParameter);

            var product =await _productRepository.GetById(productUpdateDto.Id);
            if (product == null)
                return new ErrorResult(Messages.DataNotFound);

            var mappedProduct = _mapper.Map(productUpdateDto, product);
            await _productRepository.Update(mappedProduct);

            return new SuccessResult();
        }

    }
}
