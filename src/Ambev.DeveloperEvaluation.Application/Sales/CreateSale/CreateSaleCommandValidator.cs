using Ambev.DeveloperEvaluation.Application.Sales.ModelValidators;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    public CreateSaleCommandValidator()
    {
        RuleFor(x => x.BranchId)
            .NotEmpty().WithMessage("Branch ID is required.");
        RuleFor(x => x.Items)
            .NotNull().NotEmpty().WithMessage("Item list cannot be null or empty");

        RuleForEach(x => x.Items).SetValidator(new CreateSaleItemDtoValidator());
    }
}