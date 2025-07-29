using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Branches.GetBranches
{
    internal class GetBranchesCommandValidator : AbstractValidator<GetBranchesCommand>
    {
        public GetBranchesCommandValidator()
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