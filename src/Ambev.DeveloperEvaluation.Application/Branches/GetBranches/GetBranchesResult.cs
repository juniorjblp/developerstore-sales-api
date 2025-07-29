using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Branches.GetBranches
{
    public record GetBranchesResult(List<Branch> Branches);
}
