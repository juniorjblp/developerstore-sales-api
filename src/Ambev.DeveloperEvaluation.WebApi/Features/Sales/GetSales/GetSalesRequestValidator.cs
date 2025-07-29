using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales
{
    public class GetSalesRequestValidator : AbstractValidator<GetSalesRequest>
    {   public GetSalesRequestValidator()
        {
            RuleFor(x => x.CustomerId)
            .NotEmpty()
            .WithMessage("Customer ID is required.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date is required.")
                .Must(BeAValidDate).WithMessage("Start date must be a valid date.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date is required.")
                .Must(BeAValidDate).WithMessage("End date must be a valid date.");

            RuleFor(x => x)
                .Must(HaveValidDateRange)
                .When(x => BeAValidDate(x.StartDate) && BeAValidDate(x.EndDate))
                .WithMessage("End date must be greater than or equal to start date.");

            RuleFor(x => x.PageNumber)
                .GreaterThan(0)
                .WithMessage("Page number must be greater than 0.");

            RuleFor(x => x.PageSize)
                .GreaterThan(0)
                .WithMessage("Page size must be greater than 0.");
        }

        private bool BeAValidDate(string date)
        {
            return DateTime.TryParse(date, out _);
        }

        private bool HaveValidDateRange(GetSalesRequest command)
        {
            var start = DateTime.Parse(command.StartDate);
            var end = DateTime.Parse(command.EndDate);
            return start <= end;
        }
    }
}
