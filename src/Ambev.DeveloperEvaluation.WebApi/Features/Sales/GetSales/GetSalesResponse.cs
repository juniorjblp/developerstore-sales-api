using Ambev.DeveloperEvaluation.Application.Sales.Models;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales
{
    public record GetSalesResponse(List<SalesDto> Sales);
}
