using Ambev.DeveloperEvaluation.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public int SaleNumber { get; set; }
        public DateTime SaleDate { get; set; }

        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public Guid BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public bool IsCancelled { get; set; }

        private readonly List<SaleItem> _items = [];
        public IReadOnlyCollection<SaleItem> Items => _items.AsReadOnly();

        public decimal TotalDiscount => _items.Sum(i => i.Discount);

        public decimal TotalAmount => _items.Sum(i => i.Total);

        [NotMapped]
        public string FormattedSaleNumber => $"SL-{SaleNumber:D5}";

        public static Sale Create(Guid customerId, string customerName, Branch branch, List<SaleItem> items)
        {
            if (items == null || items.Count == 0)
                throw new ArgumentException("Sale must have at least one item.");

            var sale = new Sale
            {
                CustomerId = customerId,
                CustomerName = customerName,
                BranchId = branch.Id,
                Branch = branch,
                IsCancelled = false
            };

            foreach (var item in items)
            {
                sale._items.Add(item);
            }

            // Log event
            Console.WriteLine($"[EVENT] SaleCreated: {sale.Id}");

            return sale;
        }


        public void Cancel()
        {
            IsCancelled = true;
            Console.WriteLine($"[EVENT] SaleCancelled: {Id}");
        }
    }
}
