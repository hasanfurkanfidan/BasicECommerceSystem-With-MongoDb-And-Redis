using Business.Abstract;
using Entities.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductCreateDto productCreateDto)
        {
            return GetResponseOnlyResult(await _productService.CreateProduct(productCreateDto));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return GetResponseOnlyResult(await _productService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return GetResponseOnlyResult(await _productService.GetProductById(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDto productUpdateDto)
        {
            return GetResponseOnlyResult(await _productService.UpdateProduct(productUpdateDto));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            return GetResponseOnlyResult(await _productService.DeleteProduct(id));
        }
    }
}
