namespace ProductManagement.Application.Products;

public class GetProductQuery
{
    public Guid Id { get; }

    public GetProductQuery(Guid id)
    {
        Id = id;
    }
}