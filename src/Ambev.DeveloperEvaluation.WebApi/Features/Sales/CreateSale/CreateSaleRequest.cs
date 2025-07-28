using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Models;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class CreateSaleRequest
{
    public Guid BranchId { get; set; }

    public List<CreateSaleItemRequest> Items { get; set; } = [];
}
