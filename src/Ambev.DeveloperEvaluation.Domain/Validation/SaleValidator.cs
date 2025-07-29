using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator() 
        {
            RuleFor(sale => sale.CustomerId)
                .NotEmpty().WithMessage("Customer ID cannot be empty.");
            RuleFor(sale => sale.CustomerName)
                .NotEmpty().WithMessage("Customer name cannot be empty.")
                .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters.");
            RuleFor(sale => sale.Branch)
                .NotNull().WithMessage("Branch cannot be null.");
            RuleFor(sale => sale.Items)
                .NotEmpty().WithMessage("Sale must have at least one item.")
                .Must(items => items.Count > 0).WithMessage("Sale must have at least one item.");
        }
    }
}
