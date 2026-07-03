using Microsoft.AspNetCore.Mvc;
using ProductService.Controllers;

namespace ProductServiceTests.UnitTests;

public class ProductServiceControllerTests
{
    [Theory]
    [InlineData(1)]
    [InlineData(0)]
    [InlineData(-5)]
    public void GetProductById_ReturnsExpectedProduct_ForAnyId(int id)
    {
        // Arrange
        var controller = new ProductServiceController();

        // Act
        var result = controller.GetProductById(id);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var product = Assert.IsType<Product>(okResult.Value);

        Assert.Equal(id, product.Id);
        Assert.Equal("Sample Product", product.Name);
        Assert.Equal(19.99m, product.Price);
    }

    [Fact]
    public void GetAllProducts_ReturnsExpectedProductList()
    {
        // Arrange
        var controller = new ProductServiceController();

        // Act
        var result = controller.GetAllProducts();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var products = Assert.IsType<List<Product>>(okResult.Value);

        Assert.Equal(3, products.Count);

        Assert.Collection(
            products,
            product =>
            {
                Assert.Equal(1, product.Id);
                Assert.Equal("Product 1", product.Name);
                Assert.Equal(9.99m, product.Price);
            },
            product =>
            {
                Assert.Equal(2, product.Id);
                Assert.Equal("Product 2", product.Name);
                Assert.Equal(14.99m, product.Price);
            },
            product =>
            {
                Assert.Equal(3, product.Id);
                Assert.Equal("Product 3", product.Name);
                Assert.Equal(29.99m, product.Price);
            });
    }
}
