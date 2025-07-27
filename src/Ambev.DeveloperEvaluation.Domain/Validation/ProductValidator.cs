using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    /// <summary>
    /// Implements validation rules for the Product entity.
    /// </summary>
    public class ProductValidator : AbstractValidator<Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductValidator"/> class.
        /// </summary>
        /// <remarks>
        ///  This constructor sets up the validation rules for the Product entity.
        ///  The rules include checks for required fields, maximum lengths, and value constraints.
        ///  - Name: Required, max length 100 characters
        ///  - Description: Required, max length 500 characters
        ///  - Price: Must be greater than zero
        ///  - Category: Required, max length 50 characters
        ///  - Quantity: Must be greater than or equal to zero
        ///  - IsActive: Must not be null (true or false)
        ///  - The rules ensure that the Product entity is valid before it can be processed or stored.
        /// </remarks>
        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must not exceed 100 characters.");
            RuleFor(product => product.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
            RuleFor(product => product.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(product => product.Category)
                .NotEmpty().WithMessage("Category is required.")
                .MaximumLength(50).WithMessage("Category must not exceed 50 characters.");
            RuleFor(product => product.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity cannot be negative.");
            RuleFor(product => product.IsActive)
                .NotNull().WithMessage("IsActive must be true or false.");
        }
    }
}
