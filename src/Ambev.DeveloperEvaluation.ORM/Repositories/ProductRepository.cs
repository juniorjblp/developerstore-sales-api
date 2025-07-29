using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class ProductRepository(DefaultContext context) : IProductRepository
    {
        public async Task<Product?> GetByIdAsync(Guid id)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            return await context.Products
                .Where(p => ids.Contains(p.Id))
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await context.Products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }
    }
}
