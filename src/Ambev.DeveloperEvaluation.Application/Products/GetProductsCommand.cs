using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products
{
    public record GetProductsCommand(int PageNumber, int PageSize) : IRequest<GetProductsResult>
    {
        public ValidationResultDetail Validate()
        {
            var validator = new GetProductsCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
