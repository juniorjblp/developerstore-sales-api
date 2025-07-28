using Ambev.DeveloperEvaluation.Domain.Common;

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

        /// <summary>
        /// Creates a SaleItem based on the selected product and quantity.
        /// Applies business rules like discount tiers and validates the input.
        /// </summary>
        /// <param name="product">The product being sold. Must have a valid name and price.</param>
        /// <param name="quantity">Number of units (allowed range: 1 to 20).</param>
        /// <returns>A new SaleItem instance with discount applied if applicable.</returns>
        /// <exception cref="DomainException">
        /// Thrown when the product is invalid or the quantity is out of range.
        /// </exception>
        public static SaleItem Create(Product product, int quantity)
        {
            if (product == null)
                throw new DomainException("Produto não pode ser nulo.");

            if (string.IsNullOrWhiteSpace(product.Name))
                throw new DomainException("Nome do produto é obrigatório.");

            if (quantity < 1)
                throw new DomainException("A quantidade deve ser no mínimo 1.");

            if (quantity > MaxQuantity)
                throw new DomainException($"Não é permitido vender mais de {MaxQuantity} unidades do mesmo produto.");

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

        /// <summary>
        /// Applies business rules for quantity-based discounts:
        /// - More than 10 units: 20% discount
        /// - Between 4 and 9 units: 10% discount
        /// - Less than 4 units: no discount
        /// </summary>
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
