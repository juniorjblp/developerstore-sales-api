using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Models;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public class CreateSaleResponse
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public Guid BranchId { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public List<CreateSaleItemResponse> Items { get; set; } = [];
    public decimal Discount { get; set; }
    public decimal Total { get; set; }
}
