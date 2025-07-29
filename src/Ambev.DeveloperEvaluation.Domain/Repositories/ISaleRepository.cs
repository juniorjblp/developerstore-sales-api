using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Sale operations
    /// </summary>
    public interface ISaleRepository
    {
        /// <summary>
        /// Creates a new Sale record in the repository
        /// </summary>
        /// <param name="sale">The Sale to be created</param>
        /// <param name="cancellationToken">Cacellation token</param>
        /// <returns></returns>
        Task<Sale> CreateAsync(Sale sale, CancellationToken cancellationToken);
        Task<List<Sale>> GetSalesAsync(Guid customerId, DateTime startDate, DateTime endDate, int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
