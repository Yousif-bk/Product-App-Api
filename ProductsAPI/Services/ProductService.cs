using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Model;

namespace ProductsApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductModel> GetProduct(int id)
        {
            return await _context.Products.SingleOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<ProductModel> CreateProduct(ProductModel product)
        {
            await _context.Products.AddAsync(product);
            _context.SaveChanges();
            return product;
        }

        public ProductModel DeleteProduct(ProductModel product)
        {
            _context.Remove(product);
            _context.SaveChanges();
            return product;
        }

       

        public ProductModel UpdateProduct(ProductModel product)
        {
            _context.Update(product);
            _context.SaveChanges();
            return product;
        }

   
    }
}
