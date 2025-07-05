using ProductManagement.Domain;

namespace ProductManagement.Application.Products;

public class GetProductHandler
{
    private readonly IProductRepository _repository;

    public GetProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product?> HandleAsync(GetProductQuery query)
    {
        return await _repository.GetByIdAsync(query.Id);
    }
}