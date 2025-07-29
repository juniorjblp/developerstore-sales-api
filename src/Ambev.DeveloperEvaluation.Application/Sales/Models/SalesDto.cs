namespace Ambev.DeveloperEvaluation.Application.Sales.Models
{
    public record SalesDto(
        Guid Id, 
        int SaleNumber, 
        DateTime SaleDate, 
        Guid CustomerId, 
        string CustomerName, 
        Guid BranchId, 
        string BranchName, 
        bool IsCancelled, 
        List<SaleItemDto> Items,
        decimal TotalDiscount,
        decimal TotalAmount);
}
