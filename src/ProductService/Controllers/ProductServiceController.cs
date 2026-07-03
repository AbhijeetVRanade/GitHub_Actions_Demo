using Microsoft.AspNetCore.Mvc;

namespace ProductService.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductServiceController : ControllerBase
{
    [HttpGet("product/{id}")]
    public IActionResult GetProductById(int id)
    {
        var product = new Product
        {
            Id = id,
            Name = "Sample Product",
            Price = 19.99m
        };

        return Ok(product);
    }

    [HttpGet("products")]
    public IActionResult GetAllProducts()
    {
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Product 1", Price = 9.99m },
            new Product { Id = 2, Name = "Product 2", Price = 14.99m },
            new Product { Id = 3, Name = "Product 3", Price = 29.99m }
        };

        return Ok(products);
    }
}
