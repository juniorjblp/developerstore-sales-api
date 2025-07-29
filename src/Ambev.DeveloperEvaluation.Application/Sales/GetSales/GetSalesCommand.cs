using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    public record GetSalesCommand(Guid CustomerId, string StartDate, string EndDate, int PageNumber, int PageSize) : IRequest<GetSalesResult> 
    {
        public ValidationResultDetail Validate()
        {
            var validator = new GetSalesCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
