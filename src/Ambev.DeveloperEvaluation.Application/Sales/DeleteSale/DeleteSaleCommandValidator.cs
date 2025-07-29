using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleCommandValidator : AbstractValidator<DeleteSaleCommand>
    {
        public DeleteSaleCommandValidator() 
        {
            RuleFor(command => command.Id)
                .NotEmpty().WithMessage("Sale ID must not be empty.");
        }
    }
}
