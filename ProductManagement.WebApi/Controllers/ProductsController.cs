using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Products;
using ProductManagement.Domain;

namespace ProductManagement.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly CreateProductHandler _createProductHandler;
    private readonly GetProductHandler _getProductHandler;
    private readonly GetAllProductsHandler _getAllProductsHandler;

    public ProductsController(
        ILogger<ProductsController> logger,
        CreateProductHandler createHandler,
        GetProductHandler getHandler,
        GetAllProductsHandler getAllHandler)
    {
        _logger = logger;
        _createProductHandler = createHandler;
        _getProductHandler = getHandler;
        _getAllProductsHandler = getAllHandler;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCommand command)
    {
        var id = await _createProductHandler.HandleAsync(command);
        return Ok(id);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(Guid id)
    {
        var product = await _getProductHandler.HandleAsync(new GetProductQuery(id));
        return product is null ? NotFound() : Ok(product);
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll()
    {
        var products = await _getAllProductsHandler.HandleAsync();
        return Ok(products);
    }
}