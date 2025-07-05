using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Products;
using ProductManagement.Domain;

namespace ProductManagement.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ILogger<ProductsController> _logger;
    private readonly CreateProductHandler _createHandler;
    private readonly GetProductHandler _getHandler;
    private readonly GetAllProductsHandler _getAllHandler;

    public ProductsController(
        ILogger<ProductsController> logger,
        CreateProductHandler createHandler,
        GetProductHandler getHandler,
        GetAllProductsHandler getAllHandler)
    {
        _logger = logger;
        _createHandler = createHandler;
        _getHandler = getHandler;
        _getAllHandler = getAllHandler;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCommand command)
    {
        var id = await _createHandler.HandleAsync(command);
        return Ok(id);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(Guid id)
    {
        var product = await _getHandler.HandleAsync(new GetProductQuery(id));
        return product is null ? NotFound() : Ok(product);
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll()
    {
        var products = await _getAllHandler.HandleAsync();
        return Ok(products);
    }
}