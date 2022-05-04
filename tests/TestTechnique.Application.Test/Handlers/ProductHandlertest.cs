using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using TestTechnique.Application.Commons;
using TestTechnique.Application.Contracts;
using TestTechnique.Application.Handlers;
using TestTechnique.Domain.Models;
using TestTechnique.Domain.Repositories;
using TestTechnique.Persistence.Repositories;
using TestTechnique.WebApi.Controllers;
using Xunit;

namespace TestTechnique.Application.Test.Handlers;
public class ProductHandlertest
{
    private readonly ProductHandler _productHandler;
    private readonly Mock<IProductRepository> _productRepository;

    public ProductHandlertest()
    {
        _productRepository = new Mock<IProductRepository>();
        _productHandler = new ProductHandler(_productRepository.Object);
    }

    [Fact]
    public async Task Get_Many()
    {
        // Arrange
        _productRepository
            .Setup(x => x.GetAllAsync())
            .ReturnsAsync(new List<Product>());


        // Act
        var response = await _productHandler.GetAllAsync();

        // Assert
        Assert.NotNull(response);
        var content = Assert.IsAssignableFrom<IEnumerable<ProductDto>>(response);
        Assert.NotNull(content);
    }
}

