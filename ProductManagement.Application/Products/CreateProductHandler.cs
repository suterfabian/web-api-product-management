using ProductManagement.Domain;

namespace ProductManagement.Application.Products;

public class CreateProductHandler
{
    private readonly IProductRepository _repository;

    public CreateProductHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> HandleAsync(CreateProductCommand command)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
            Price = command.Price
        };

        await _repository.AddAsync(product);
        return product.Id;
    }
}