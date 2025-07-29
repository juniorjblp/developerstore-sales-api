using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository(DefaultContext context) : ISaleRepository
    {
        public async Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken)
        {   
            await context.Sales.AddAsync(sale, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return sale;
        }

        public async Task<List<Sale>> GetSalesAsync(Guid customerId, DateTime startDate, DateTime endDate, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await context.Sales
                .Where(s => s.CustomerId == customerId && s.SaleDate >= startDate && s.SaleDate <= endDate)
                .OrderByDescending(s => s.SaleDate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Include(s => s.Branch)
                .Include(s => s.Items)
                .ToListAsync(cancellationToken);
        }
    }
}
