using ProductsApi.Model;
using System.Numerics;

namespace ProductsApi.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetProductsAsync();
        Task<ProductModel> GetProduct(int id);
        Task<ProductModel> CreateProduct(ProductModel product);
        ProductModel UpdateProduct(ProductModel product);
        ProductModel DeleteProduct(ProductModel product);

    }
}
