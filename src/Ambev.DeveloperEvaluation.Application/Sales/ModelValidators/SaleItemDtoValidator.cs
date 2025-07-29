using Ambev.DeveloperEvaluation.Application.Sales.Models;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.ModelValidators
{
    public class SaleItemDtoValidator : AbstractValidator<SaleItemDto>
    {
        public SaleItemDtoValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product ID is required.");
            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        }
    }
}
