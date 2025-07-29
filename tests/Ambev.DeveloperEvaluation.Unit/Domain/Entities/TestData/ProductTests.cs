using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Validation;
using System;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class ProductTests
    {
        private Product CreateValidProduct()
        {
            return new Product
            {
                Name = "Cerveja IPA",
                Description = "Cerveja artesanal com lúpulo cítrico",
                Price = 12.99m,
                Category = "Bebidas",
                Quantity = 50,
                CreatedAt = DateTime.UtcNow
            };
        }

        [Fact(DisplayName = "Should validate successfully with all required fields")]
        public void Validate_WithValidData_ShouldBeValid()
        {
            var product = CreateValidProduct();

            var result = product.Validate();

            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Theory(DisplayName = "Should return validation errors when mandatory fields are missing")]
        [InlineData("", "Descrição válida", 10.0, "Categoria")]
        [InlineData("Nome válido", "", 10.0, "Categoria")]
        [InlineData("Nome válido", "Descrição válida", 0.0, "Categoria")]
        [InlineData("Nome válido", "Descrição válida", 10.0, "")]
        public void Validate_WithMissingFields_ShouldBeInvalid(string name, string desc, decimal price, string category)
        {
            var product = new Product
            {
                Name = name,
                Description = desc,
                Price = price,
                Category = category,
                CreatedAt = DateTime.UtcNow
            };

            var result = product.Validate();

            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }

        [Fact(DisplayName = "IsInStock should return true when quantity is greater than zero")]
        public void IsInStock_WhenQuantityPositive_ShouldReturnTrue()
        {
            var product = CreateValidProduct();
            product.Quantity = 5;

            Assert.True(product.IsInStock);
        }

        [Fact(DisplayName = "IsInStock should return false when quantity is zero")]
        public void IsInStock_WhenQuantityZero_ShouldReturnFalse()
        {
            var product = CreateValidProduct();
            product.Quantity = 0;

            Assert.False(product.IsInStock);
        }

        [Fact(DisplayName = "Activate should set IsActive to true and update timestamp")]
        public void Activate_ShouldSetIsActiveTrue_AndUpdateTimestamp()
        {
            var product = CreateValidProduct();
            product.IsActive = false;

            product.Activate();

            Assert.True(product.IsActive);
            Assert.NotNull(product.UpdatedAt);
        }

        [Fact(DisplayName = "Deactivate should set IsActive to false and update timestamp")]
        public void Deactivate_ShouldSetIsActiveFalse_AndUpdateTimestamp()
        {
            var product = CreateValidProduct();

            product.Deactivate();

            Assert.False(product.IsActive);
            Assert.NotNull(product.UpdatedAt);
        }

        [Fact(DisplayName = "SetOutOfStock should zero quantity and update timestamp")]
        public void SetOutOfStock_ShouldZeroQuantity_AndUpdateTimestamp()
        {
            var product = CreateValidProduct();
            product.Quantity = 20;

            product.SetOutOfStock();

            Assert.Equal(0, product.Quantity);
            Assert.NotNull(product.UpdatedAt);
        }
    }
}
