using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Models;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

public record CreateSaleRequest(Guid BranchId, List<CreateSaleItemRequest> Items);
