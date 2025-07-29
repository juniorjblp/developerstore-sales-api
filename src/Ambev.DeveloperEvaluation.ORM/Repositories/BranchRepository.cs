using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class BranchRepository(DefaultContext context) : IBranchRepository
    {
        public async Task<List<Branch>> GetBranchesAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await context.Branches
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task<Branch?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await context.Branches.FirstOrDefaultAsync(b => b.Id == id, cancellationToken: cancellationToken);
        }
    }
}
