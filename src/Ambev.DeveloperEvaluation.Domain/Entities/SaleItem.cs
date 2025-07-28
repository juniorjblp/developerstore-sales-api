using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; } = string.Empty;
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }

        public Guid SaleId { get; set; }
        public Sale Sale { get; set; } = null!;

        public decimal Total => (UnitPrice * Quantity) - Discount;

        public static SaleItem Create(Product product, int quantity)
        {
            if (quantity < 1)
                throw new ArgumentException("Quantity must be at least 1.");

            if (quantity > 20)
                throw new ArgumentException("Cannot sell more than 20 units of the same product.");

            decimal discount = 0;

            if (quantity >= 10)
            {
                discount = 0.2m * product.Price * quantity;
            }
            else if (quantity >= 4)
            {
                discount = 0.1m * product.Price * quantity;
            }

            return new SaleItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Quantity = quantity,
                UnitPrice = product.Price,
                Discount = discount
            };
        }
    }
}
