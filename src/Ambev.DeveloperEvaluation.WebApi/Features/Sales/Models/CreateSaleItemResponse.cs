namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Models
{
    public record CreateSaleItemResponse(Guid ProductId, string ProductName, decimal UnitPrice, int Quantity, decimal Total);
}
