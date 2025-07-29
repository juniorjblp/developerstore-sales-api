using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IBranchRepository
    {
        Task<List<Branch>> GetBranchesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
