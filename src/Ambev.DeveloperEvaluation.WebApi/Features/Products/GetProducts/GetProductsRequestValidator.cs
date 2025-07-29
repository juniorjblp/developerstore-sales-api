using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts
{
    public class GetProductsRequestValidator : AbstractValidator<GetProductsRequest>
    {
        public GetProductsRequestValidator()
        {
            RuleFor(command => command.PageNumber)
               .Must(pageNumber => pageNumber > 0)
               .WithMessage("Page number must be grether than 0.");
            RuleFor(command => command.PageSize)
                .Must(pageSize => pageSize > 0 && pageSize <= 100)
                .WithMessage("Page size must be grether than 0 and less than or equal to 100.");
        }
    }
}
