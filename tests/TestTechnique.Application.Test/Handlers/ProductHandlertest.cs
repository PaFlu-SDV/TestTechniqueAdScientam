using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using TestTechnique.Application.Commons;
using TestTechnique.Application.Contracts;
using TestTechnique.Application.Handlers;
using TestTechnique.Domain.Exceptions;
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

    [Fact]
    public async Task Get_One()
    {
        // Arrange
        _productRepository
            .Setup(x => x.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync(new Product());

        // Act
        var response = await _productHandler.GetAsync(Guid.NewGuid());

        // Assert
        Assert.NotNull(response);
        var content = Assert.IsAssignableFrom<ProductDto>(response);
        Assert.NotNull(content);
        Assert.True(content.Name == It.IsAny<string>());
        Assert.True(content.Description == It.IsAny<string>());
        Assert.True(content.Price == It.IsAny<int>());
        Assert.True(content.Id == It.IsAny<Guid>());
    }

    [Fact]
    public async Task Post()
    {
        // Arrange
        _productRepository
            .Setup(x => x.AddAsync(It.IsAny<Product>()))
            .ReturnsAsync(Guid.NewGuid());

        // Act
        var response = await _productHandler.AddAsync(new ProductDto());

        // Assert
        Assert.IsType(Guid.NewGuid().GetType(), response);
        Assert.True(response != Guid.Empty);
    }

    [Fact]
    public async Task Put()
    {
        // Arrange
        _productRepository
            .Setup( x => x.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync(new Product());
        _productRepository
            .Setup(x => x.UpdateAsync(It.IsAny<Product>()));

        // Act
        var response = await _productHandler.UpdateAsync(new ProductDto());

        // Assert
        Assert.NotNull(response);
        var content = Assert.IsAssignableFrom<ProductDto>(response);
        Assert.True(content.Name == It.IsAny<string>());
        Assert.True(content.Description == It.IsAny<string>());
        Assert.True(content.Price == It.IsAny<int>());
        Assert.True(content.Id == It.IsAny<Guid>());
    }

    [Fact]
    public async Task Delete()
    {
        // Arrange
        _productRepository
            .Setup(x => x.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync(new Product());
        _productRepository
            .Setup(x => x.DeleteAsync(It.IsAny<Product>()));

        // Act
        var response = _productHandler.DeleteAsync(It.IsAny<Guid>());

        // Assert
        Assert.NotNull(response);
        await Assert.IsAssignableFrom<Task>(response);
    }

}

