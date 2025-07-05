using ProductManagement.Core.Domain;

namespace ProductManagement.Core.Application.Products;

public interface IProductRepository
{
    Product AddProduct(Product product);

    IEnumerable<Product> GetProducts();
}