using Ambev.DeveloperEvaluation.Application.Sales.Models;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Represents the response returned after successfully creating a new sale.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateSaleResult
{
    public Guid Id { get; set; }
    public string SaleNumber { get; set; } = string.Empty;
    public DateTime SaleDate { get; set; }
    public Guid BranchId { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public List<CreateSaleItemResult> Items { get; set; } = [];
    public decimal Total { get; set; }
}
