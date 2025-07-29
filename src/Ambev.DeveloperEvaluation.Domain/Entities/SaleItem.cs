using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleItem : BaseEntity
    {
        private const int MinQuantityForDiscount = 4;
        private const int MidQuantityForDiscount = 10;
        private const int MaxQuantity = 20;

        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal Discount { get; private set; }

        public Guid SaleId { get; private set; }
        public Sale Sale { get; private set; } = null!;

        public decimal Total => (UnitPrice * Quantity) - Discount;

        private SaleItem() { }

        public ValidationResultDetail Validate()
        {
            var validator = new SaleItemValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        public static SaleItem Create(Product product, int quantity)
        {
            if (product == null)
                throw new DomainException("Product cannot be null.");

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new DomainException("Product name is erquired.");

            if (quantity < 1)
                throw new DomainException("Quantity must be greather than 0.");

            if (quantity > MaxQuantity)
                throw new DomainException($"Cannot sell more than {MaxQuantity} identical items.");

            var discount = CalculateDiscount(product.Price, quantity);

            return new SaleItem
            {
                ProductId = product.Id,
                ProductName = product.Name,
                Quantity = quantity,
                UnitPrice = product.Price,
                Discount = discount
            };
        }

        private static decimal CalculateDiscount(decimal unitPrice, int quantity)
        {
            if (quantity >= MidQuantityForDiscount)
                return 0.2m * unitPrice * quantity;

            if (quantity >= MinQuantityForDiscount)
                return 0.1m * unitPrice * quantity;

            return 0m;
        }
    }
}
