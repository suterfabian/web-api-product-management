namespace ProductManagement.Domain.Interfaces;

public interface IProductRepository
{
    Task<List<Product>> GetAsync();

    Task<Product?> GetByIdAsync(Guid id);

    Task AddAsync(Product product);
}