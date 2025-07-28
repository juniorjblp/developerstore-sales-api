using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Models;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ModelValidators
{
    public class CreateSaleItemRequestValidator : AbstractValidator<CreateSaleItemRequest>
    {
        public CreateSaleItemRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Product Id is required!");
            RuleFor(x => x.Quantity)
                .InclusiveBetween(1, 20)
                .WithMessage("Product quantity must be between 1 and 20");
        }
    }
}
