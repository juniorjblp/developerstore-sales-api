namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Models
{
    public class CreateSaleItemResponse
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = default!;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
