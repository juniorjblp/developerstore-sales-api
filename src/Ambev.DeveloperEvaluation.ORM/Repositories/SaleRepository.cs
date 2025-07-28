using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;

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
    }
}
