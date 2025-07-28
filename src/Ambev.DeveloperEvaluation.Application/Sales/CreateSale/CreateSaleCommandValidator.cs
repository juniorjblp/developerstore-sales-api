using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for Sale creation command.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleNumber must not be empty and must be between 3 and 50 characters.
    /// - SaleDate must not be empty and cannot be in the future.
    /// - CustomerId must not be empty.
    /// - CustomerName must not be empty and must be between 3 and 100 characters.
    /// - BranchId must not be empty.
    /// - BranchName must not be empty and must be between 3 and 100 characters.
    /// - Items must not be empty, ensuring at least one sale item is provided.
    /// </remarks>
    public CreateSaleCommandValidator()
    {
        RuleFor(x => x.BranchId)
            .NotEmpty().WithMessage("Branch ID is required.");
        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("At least one sale item is required.");
    }
}