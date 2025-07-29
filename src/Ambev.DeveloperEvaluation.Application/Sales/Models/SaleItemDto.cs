
namespace Ambev.DeveloperEvaluation.Application.Sales.Models
{
    public record SaleItemDto(Guid ProductId, string ProductName, int Quantity, decimal UnitPrice, decimal Discount);
}
