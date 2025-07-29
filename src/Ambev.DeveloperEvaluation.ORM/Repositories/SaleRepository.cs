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

        public async Task<Sale?> GetSaleByIdAsync(Guid id)
        {
            return await context.Sales
                .Include(s => s.Branch)
                .Include(s => s.Items)
                .FirstOrDefaultAsync(s => s.Id == id && s.IsDeleted == false);
        }

        public async Task<List<Sale>> GetSalesAsync(Guid customerId, DateTime startDate, DateTime endDate, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            return await context.Sales
                .Where(s => s.CustomerId == customerId && s.SaleDate >= startDate && s.SaleDate <= endDate && s.IsDeleted == false)
                .OrderByDescending(s => s.SaleDate)
                .Include(s => s.Branch)
                .Include(s => s.Items)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateSaleAsync(Sale sale, CancellationToken cancellationToken)
        {
            context.Sales.Update(sale);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
