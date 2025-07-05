using FluentAssertions;
using Moq;
using ProductManagement.Application.Products;
using ProductManagement.Domain;
using ProductManagement.Domain.Interfaces;

namespace ProductManagement.UnitTests.Products;

public class CreateProductHandlerTests
{
    [Fact]
    public async Task Handle_Should_Create_Product_And_Return_Id()
    {
        // Arrange
        var mockRepo = new Mock<IProductRepository>();
        var handler = new CreateProductHandler(mockRepo.Object);
        var command = new CreateProductCommand("TestProduct", 42);

        // Act
        var result = await handler.HandleAsync(command);

        // Assert
        result.Should().NotBeEmpty();
        mockRepo.Verify(r => r.AddAsync(It.Is<Product>(
            p => p.Name == "TestProduct" && p.Price == 42)), Times.Once);
    }
}