using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using ProductManagement.Application.Products;
using ProductManagement.Domain;

namespace ProductManagement.IntegrationTests.Controllers;

public class ProductsControllerTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public ProductsControllerTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Post_CreateProduct_ShouldReturnId_AndBeRetrievable()
    {
        // Arrange
        var command = new CreateProductCommand("IntegrationTestProduct", 99);

        // Act
        var response = await _client.PostAsJsonAsync("/products", command);
        response.EnsureSuccessStatusCode();

        var id = await response.Content.ReadFromJsonAsync<Guid>();

        // Abrufen und prüfen
        var getResponse = await _client.GetAsync($"/products/{id}");
        getResponse.EnsureSuccessStatusCode();

        var product = await getResponse.Content.ReadFromJsonAsync<Product>();

        // Assert
        product.Should().NotBeNull();
        product!.Name.Should().Be("IntegrationTestProduct");
        product.Price.Should().Be(99);
    }

    [Fact]
    public async Task GetAll_ShouldReturn_Products()
    {
        // Act
        var response = await _client.GetAsync("/products");
        response.EnsureSuccessStatusCode();

        var products = await response.Content.ReadFromJsonAsync<List<Product>>();

        // Assert
        products.Should().NotBeNull();
        products!.Count.Should().BeGreaterThanOrEqualTo(0);
    }
}