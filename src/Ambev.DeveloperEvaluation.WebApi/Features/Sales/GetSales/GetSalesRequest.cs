using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales
{
    public record GetSalesRequest
    {
        public Guid CustomerId { get; init; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }

        [DataType(DataType.Date)]
        public string StartDate { get; init; } = string.Empty;

        [DataType(DataType.Date)]
        public string EndDate { get; init; } = string.Empty;
    }

}
