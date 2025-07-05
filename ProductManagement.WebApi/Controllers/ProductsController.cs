using Microsoft.AspNetCore.Mvc;
using ProductManagement.Core.Domain;

namespace ProductManagement.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Product
        {
            Id = index,
            Name = $"Product-{index}",
            Price = Random.Shared.Next(9000)
        })
        .ToArray();
    }
}