using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(Guid id);
        Task<List<Product>> GetByIdsAsync(IEnumerable<Guid> ids);
    }

}
