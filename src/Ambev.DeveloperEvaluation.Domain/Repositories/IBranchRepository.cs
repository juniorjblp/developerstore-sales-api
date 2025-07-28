using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IBranchRepository
    {
        Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
