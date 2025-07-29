using Ambev.DeveloperEvaluation.WebApi.Features.Sales.ModelValidators;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(x => x.BranchId)
            .NotEmpty().WithMessage("Branch ID is required.");
        RuleFor(x => x.Items)
            .NotNull().NotEmpty().WithMessage("Item list cannot be null or empty");

        RuleForEach(x => x.Items).SetValidator(new CreateSaleItemRequestValidator());
    }
}

