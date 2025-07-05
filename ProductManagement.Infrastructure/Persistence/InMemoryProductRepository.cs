using ProductManagement.Core.Application.Products;
using ProductManagement.Core.Domain;

namespace ProductManagement.Infrastructure.Persistence;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = [];

    public InMemoryProductRepository()
    {
        Init();
    }

    public Product AddProduct(Product product)
    {
        _products.Add(product);

        return product;
    }

    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }

    public void Init()
    {
        _products.AddRange(Enumerable.Range(1, 10).Select(index => new Product
        {
            Id = index,
            Name = $"Product-{index}",
            Price = Random.Shared.Next(9000)
        }));
    }
}