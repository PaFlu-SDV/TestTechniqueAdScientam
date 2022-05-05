using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using TestTechnique.Application.Commons;
using TestTechnique.Application.Contracts;
using TestTechnique.Domain.Models;
using TestTechnique.Domain.Repositories;
using TestTechnique.Persistence.Repositories;
using TestTechnique.WebApi.Controllers;
using Xunit;

namespace TestTechnique.Persistence.Test.Repositories;
public class ProductRepositoriesTest
{
    private TestTechniqueDbContext _dbContext;
    private ProductRepository _productRepository;

    public ProductRepositoriesTest()
    {
        var options = new DbContextOptionsBuilder<TestTechniqueDbContext>()
     .UseInMemoryDatabase("InMemoryDb")
     .Options;
        this._dbContext = new TestTechniqueDbContext(options);
        _productRepository = new ProductRepository(this._dbContext);

    }

    public static Guid ToGuid(int value)
    {
        byte[] bytes = new byte[16];
        BitConverter.GetBytes(value).CopyTo(bytes, 0);
        return new Guid(bytes);
    }

    [Fact]
    public async Task GetAsync()
    {
        //Arrange  
        _dbContext.Products.Add(
            new Product() { Id = ToGuid(1), Name = "Product1", Description = "description", Price = 0 }
            );
        await _dbContext.SaveChangesAsync();

        //Act  
        var result = await _productRepository.GetAsync(ToGuid(1));

        //Assert  
        Assert.NotNull(result);
        Assert.NotEmpty(result.Name);
    }

    [Fact]
    public async Task GetAllAsync()
    {
        //Arrange  
        _dbContext.Products.AddRange(
            new Product() { Id = ToGuid(1), Name = "Product1", Description = "description1", Price = 1 },
            new Product() { Id = ToGuid(2), Name = "Product2", Description = "description2", Price = 2 }
            );
        await _dbContext.SaveChangesAsync();

        //Act  
        var result = await _productRepository.GetAllAsync();

        //Assert  
        Assert.NotNull(result);
        Assert.NotEmpty(result);

        var i = 1;
        foreach (var item in result)
        {
            
            Assert.Equal(item.Id, ToGuid(i));
            Assert.Equal(item.Name, "Product" + i);
            Assert.Equal(item.Description, "description" + i);
            Assert.Equal(item.Price, i);
            i++;

        }
    }

    [Fact]
    public async Task AddAsync()
    {
        //Arrange  
        var product = new Product() { Id = ToGuid(1), Name = "Product1", Description = "description", Price = 0 };

        //Act  
        var result = await _productRepository.AddAsync(product);

        //Assert  
        Assert.NotNull(result);
        Assert.Equal(_dbContext.Products.FindAsync(ToGuid(1)).Result, product);
    }

    [Fact]
    public async Task UpdateAsync()
    {
        //Arrange  
        _dbContext.Products.Add(
            new Product() { Id = ToGuid(1), Name = "Product1", Description = "description", Price = 0 }
            );
        await _dbContext.SaveChangesAsync();

        //Act
        var updatedProduct =  _dbContext.Products.FindAsync(ToGuid(1)).Result;
        updatedProduct.Name = "Product2";
        updatedProduct.Description = "description2";
        updatedProduct.Price = 10;
        var result = _productRepository.UpdateAsync(updatedProduct);

        //Assert  
        Assert.NotNull(result);
        Assert.Equal(_dbContext.Products.FindAsync(ToGuid(1)).Result, updatedProduct);
    }

    [Fact]
    public async Task DeleteAsync()
    {
        //Arrange  
        await _dbContext.Products.AddAsync(
            new Product() { Id = ToGuid(1), Name = "Product1", Description = "description", Price = 0 }
            );
        await _dbContext.SaveChangesAsync();

        //Act
        var result = _productRepository.DeleteAsync(_dbContext.Products.FindAsync(ToGuid(1)).Result);

        //Assert  
        Assert.NotNull(result);
        //Assert.False(_dbContext.Products.FindAsync(ToGuid(1)));
    }
}
