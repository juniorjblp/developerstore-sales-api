using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.ModelValidators;
using FluentValidation;

public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    public CreateSaleRequestValidator()
    {
        RuleFor(x => x.BranchId)
            .NotEmpty().WithMessage("Branch ID is required.");
        RuleFor(x => x.Items)
            .NotNull().WithMessage("A lista de itens não pode ser nula.")
            .NotEmpty().WithMessage("A venda deve conter pelo menos um item.");

        RuleForEach(x => x.Items).SetValidator(new CreateSaleItemRequestValidator());
    }
}

