using ProductManagement.Domain;
using ProductManagement.Domain.Interfaces;

namespace ProductManagement.Infrastructure.Persistence;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<Product> _products = [];

    public InMemoryProductRepository()
    {
        Init();
    }

    public Task AddAsync(Product product)
    {
        _products.Add(product);
        return Task.CompletedTask;
    }

    public Task<Product?> GetByIdAsync(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(product);
    }

    public Task<List<Product>> GetAsync()
    {
        // Rückgabe einer Kopie zur Sicherheit (Read-Only)
        return Task.FromResult(_products.ToList());
    }

    public void Init()
    {
        _products.AddRange(Enumerable.Range(1, 10).Select(index => new Product
        {
            Id = Guid.NewGuid(),
            Name = $"Product-{index}",
            Price = Random.Shared.Next(9000)
        }));
    }
}