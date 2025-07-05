using FluentAssertions;
using Moq;
using ProductManagement.Application.Products;
using ProductManagement.Domain;
using ProductManagement.Domain.Interfaces;

namespace ProductManagement.UnitTests.Products;

public class GetProductHandlerTests
{
    [Fact]
    public async Task Handle_Should_Return_Product_When_Found()
    {
        // Arrange
        var productId = Guid.NewGuid();
        var mockRepo = new Mock<IProductRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(productId)).ReturnsAsync(
            new Product { Id = productId, Name = "Test", Price = 10 });

        var handler = new GetProductHandler(mockRepo.Object);
        var query = new GetProductQuery(productId);

        // Act
        var result = await handler.HandleAsync(query);

        // Assert
        result.Should().NotBeNull();
        result!.Id.Should().Be(productId);
    }

    [Fact]
    public async Task Handle_Should_Return_Null_When_Not_Found()
    {
        // Arrange
        var mockRepo = new Mock<IProductRepository>();
        mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync((Product?)null);

        var handler = new GetProductHandler(mockRepo.Object);
        var query = new GetProductQuery(Guid.NewGuid());

        // Act
        var result = await handler.HandleAsync(query);

        // Assert
        result.Should().BeNull();
    }
}