using ProductManagement.Domain;

namespace ProductManagement.Application.Products;

public class GetAllProductsHandler
{
    private readonly IProductRepository _repository;

    public GetAllProductsHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> HandleAsync()
    {
        return await _repository.GetAsync();
    }
}