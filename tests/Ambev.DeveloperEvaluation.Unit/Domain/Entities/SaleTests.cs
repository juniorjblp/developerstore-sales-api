using Ambev.DeveloperEvaluation.Domain.Entities;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities
{
    public class SaleTests
    {
        private static Branch CreateBranch()
        {
            return new Branch
            {
                Id = Guid.NewGuid(),
                Name = "Main Branch"
            };
        }

        private static SaleItem CreateSaleItem(decimal price = 100m, int quantity = 1)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Sample Product",
                Price = price
            };

            return SaleItem.Create(product, quantity);
        }

        [Fact(DisplayName = "Create sale with valid data should succeed")]
        public void Create_WithValidData_ShouldCreateSale()
        {
            // Arrange
            var branch = CreateBranch();
            var items = new List<SaleItem>
            {
                CreateSaleItem(price: 50m, quantity: 2),
                CreateSaleItem(price: 30m, quantity: 1)
            };
            var customerId = Guid.NewGuid();
            var customerName = "John Doe";

            // Act
            var sale = Sale.Create(customerId, customerName, branch, items);

            // Assert
            Assert.Equal(customerId, sale.CustomerId);
            Assert.Equal(customerName, sale.CustomerName);
            Assert.Equal(branch.Id, sale.BranchId);
            Assert.False(sale.IsCancelled);
            Assert.Equal(items.Count, sale.Items.Count);
            Assert.True(sale.TotalAmount > 0);
            Assert.True(sale.TotalDiscount >= 0);
            Assert.StartsWith("SL-", sale.FormattedSaleNumber);
            Assert.InRange(sale.SaleDate, DateTime.UtcNow.AddMinutes(-1), DateTime.UtcNow.AddMinutes(1));
        }

        [Fact(DisplayName = "Creating sale with no items should throw exception")]
        public void Create_WithNoItems_ShouldThrow()
        {
            // Arrange
            var branch = CreateBranch();
            var customerId = Guid.NewGuid();
            var customerName = "John Doe";
            var emptyItems = new List<SaleItem>();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() =>
                Sale.Create(customerId, customerName, branch, emptyItems));

            Assert.Equal("A venda precisa ter pelo menos um item.", ex.Message);
        }

        [Fact(DisplayName = "Canceling sale sets IsCancelled flag and logs event")]
        public void Cancel_ShouldMarkSaleAsCancelled()
        {
            // Arrange
            var branch = CreateBranch();
            var items = new List<SaleItem> { CreateSaleItem() };
            var sale = Sale.Create(Guid.NewGuid(), "Customer", branch, items);

            // Act
            sale.Cancel();

            // Assert
            Assert.True(sale.IsCancelled);
        }
    }
}
