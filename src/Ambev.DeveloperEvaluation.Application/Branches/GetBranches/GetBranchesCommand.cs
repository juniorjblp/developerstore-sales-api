using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.GetBranches
{
    public record GetBranchesCommand(int PageNumber, int PageSize) : IRequest<GetBranchesResult>
    {
        public ValidationResultDetail Validate()
        {
            var validator = new GetBranchesCommandValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
