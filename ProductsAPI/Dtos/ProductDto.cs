using ProductsApi.Model;

namespace ProductsApi.Dtos
{
    public class ProductDto
    {
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
    }
}
