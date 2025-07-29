using Ambev.DeveloperEvaluation.Application.Sales.Models;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleResult
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public Guid BranchId { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public List<CreateSaleItemResult> Items { get; set; } = [];
    public decimal Discount { get; set; }
    public decimal Total { get; set; }
}
