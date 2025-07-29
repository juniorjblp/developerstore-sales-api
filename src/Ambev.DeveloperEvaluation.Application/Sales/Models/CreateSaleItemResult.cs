namespace Ambev.DeveloperEvaluation.Application.Sales.Models
{
    public record CreateSaleItemResult(Guid ProductId, string ProductName, decimal UnitPrice, int Quantity, decimal Total);
}
