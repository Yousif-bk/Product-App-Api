

using Microsoft.AspNetCore.Mvc;
using ProductsApi.Controllers;
using ProductsApi.Dtos;

namespace ProductTesting
{
    public class ProductControllerUnitTest
    {
                private readonly ProductsController _productsController;

        public ProductControllerUnitTest(ProductsController productsController)
        {
            _productsController = productsController;
        }

        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _productsController.GetAsync(456);
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var product = new ProductDto()
            {
                ProductCode = "Mx_88" ,
                Price = 500,
            };
            _productsController.ModelState.AddModelError("ProductName", "Required");
            // Act
            var badResponse = _productsController.CreateProduct(product);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Remove()
        {
            // Arrange
            var notExistingGuid = 0;
            // Act
            var badResponse = _productsController.DeleteProduct(notExistingGuid);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsNoContentResult()
        {
            // Arrange
            var existingId = 5;
            // Act
            var noContentResponse = _productsController.DeleteProduct(existingId);
            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }
    }
}