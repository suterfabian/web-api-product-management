using Microsoft.AspNetCore.Mvc;
using ProductManagement.Core.Application.Products;
using ProductManagement.Core.Domain;

namespace ProductManagement.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly IProductRepository _productRepository;

    public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepository)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    [HttpGet(Name = "GetProducts")]
    public IEnumerable<Product> Get()
    {
        return _productRepository.GetProducts();
    }

    [HttpPost(Name = "AddProduct")]
    public Product Post([FromBody] Product product)
    {
        return _productRepository.AddProduct(product);
    }
}