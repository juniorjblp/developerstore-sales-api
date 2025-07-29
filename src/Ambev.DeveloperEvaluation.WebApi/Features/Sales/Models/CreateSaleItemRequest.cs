namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.Models
{
    public record CreateSaleItemRequest(Guid ProductId, int Quantity);
}
