using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Contracts;
using ProductsApi.Dtos;
using ProductsApi.Model;
using ProductsApi.Services;

namespace ProductsApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet(ApiRoute.Product.Search)]
        public async Task<IActionResult> GetProductsAsync()
        {
            var product = await _productService.GetProductsAsync();
            return Ok(product);
        }

        [HttpGet(ApiRoute.Product.GetProduct)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var product = await _productService.GetProduct(id);

            if (product == null)
                return NotFound($"No product was found with ID:{id}");

            return Ok(product);
        }

        [HttpPost(ApiRoute.Product.Create)]
        public async Task<IActionResult> CreateProduct(ProductDto productDto)
        {
            var product = new ProductModel
            {
                ProductName = productDto.ProductName,
                ProductCode = productDto.ProductCode,
                Price = productDto.Price,
                Description = productDto.Description,
                Rating = productDto.Rating
            };
            await _productService.CreateProduct(product);
            return Ok(product);
        }

        [HttpPut(ApiRoute.Product.Update)]
        public async Task<IActionResult> UpdateAsync(byte id, [FromBody] ProductDto dto)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound($"No product was found with ID:{id}");
            }
            product.ProductName = dto.ProductName;
            product.ProductCode = dto.ProductCode;
            product.Price = dto.Price;
            product.Description = dto.Description;
            product.Rating = dto.Rating;

            _productService.UpdateProduct(product);
            return Ok(product);
        }

        [HttpDelete(ApiRoute.Product.Delete)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetProduct(id);

            if (product == null)
                return NotFound($"No product was found with ID:{id}");

            _productService.DeleteProduct(product);
            return Ok(product);
        }
    }
}
