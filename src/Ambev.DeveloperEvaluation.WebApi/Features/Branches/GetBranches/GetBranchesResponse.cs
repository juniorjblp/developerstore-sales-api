using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Branches.GetBranches
{
    public record GetBranchesResponse(List<Branch> Branches);
}
