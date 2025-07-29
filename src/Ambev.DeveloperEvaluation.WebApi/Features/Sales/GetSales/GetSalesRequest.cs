namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales
{
    public record GetSalesRequest(Guid CustomerId, DateTime StartDate, DateTime EndDate, int PageNumber, int PageSize);
}
