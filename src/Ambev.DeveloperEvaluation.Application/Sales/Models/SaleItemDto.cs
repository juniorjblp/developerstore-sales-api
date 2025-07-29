
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Application.Sales.Models
{
    public record SaleItemDto(Guid ProductId, int Quantity, decimal UnitPrice, decimal Discount, string ProductName);
}
