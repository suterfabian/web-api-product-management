namespace ProductManagement.Application.Products;

public class CreateProductCommand
{
    public string Name { get; }
    public int Price { get; }

    public CreateProductCommand(string name, int price)
    {
        Name = name;
        Price = price;
    }
}