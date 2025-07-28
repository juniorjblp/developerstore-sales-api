using Ambev.DeveloperEvaluation.Domain.Entities;
using Xunit;
using System;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class SaleItemTests
{
    private static Product CreateProduct(decimal price = 100m, string name = "Test Product")
    {
        return new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Price = price
        };
    }

    [Theory(DisplayName = "Discount calculation should follow the business rules")]
    [InlineData(1, 0)]
    [InlineData(3, 0)] 
    [InlineData(4, 40)]
    [InlineData(9, 90)]
    [InlineData(10, 200)]
    [InlineData(20, 400)]
    public void Create_WithValidQuantity_ShouldCalculateDiscountCorrectly(int quantity, decimal expectedDiscount)
    {
        // Arrange
        var product = CreateProduct();

        // Act
        var saleItem = SaleItem.Create(product, quantity);

        // Assert
        Assert.Equal(expectedDiscount, saleItem.Discount);
        Assert.Equal(quantity, saleItem.Quantity);
        Assert.Equal(product.Price, saleItem.UnitPrice);
    }

    [Fact(DisplayName = "Throws DomainException if quantity is zero or less")]
    public void Create_WhenQuantityIsZeroOrLess_ShouldThrow()
    {
        var product = CreateProduct();

        var exception = Assert.Throws<DomainException>(() => SaleItem.Create(product, 0));
        Assert.Equal("A quantidade deve ser no mínimo 1.", exception.Message);
    }

    [Fact(DisplayName = "Throws DomainException if quantity exceeds max allowed")]
    public void Create_WhenQuantityIsGreaterThanMax_ShouldThrow()
    {
        var product = CreateProduct();

        var exception = Assert.Throws<DomainException>(() => SaleItem.Create(product, 21));
        Assert.Equal("Não é permitido vender mais de 20 unidades do mesmo produto.", exception.Message);
    }

    [Fact(DisplayName = "Throws DomainException if product is null")]
    public void Create_WhenProductIsNull_ShouldThrow()
    {
        var exception = Assert.Throws<DomainException>(() => SaleItem.Create(null!, 5));
        Assert.Equal("Produto não pode ser nulo.", exception.Message);
    }

    [Fact(DisplayName = "Throws DomainException if product name is empty")]
    public void Create_WhenProductNameIsEmpty_ShouldThrow()
    {
        var product = CreateProduct(name: "");

        var exception = Assert.Throws<DomainException>(() => SaleItem.Create(product, 5));
        Assert.Equal("Nome do produto é obrigatório.", exception.Message);
    }
}
