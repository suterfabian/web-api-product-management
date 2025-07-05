using FluentAssertions;
using Moq;
using ProductManagement.Application.Products;
using ProductManagement.Domain;
using ProductManagement.Domain.Interfaces;

namespace ProductManagement.UnitTests.Products;

public class GetAllProductsHandlerTests
{
    [Fact]
    public async Task Handle_Should_Return_All_Products()
    {
        // Arrange
        var mockRepo = new Mock<IProductRepository>();
        var expected = new List<Product>
        {
            new Product { Id = Guid.NewGuid(), Name = "A", Price = 1 },
            new Product { Id = Guid.NewGuid(), Name = "B", Price = 2 }
        };

        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(expected);

        var handler = new GetAllProductsHandler(mockRepo.Object);

        // Act
        var result = await handler.HandleAsync();

        // Assert
        result.Should().HaveCount(2);
        result.Should().BeEquivalentTo(expected);
    }
}