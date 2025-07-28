using Ambev.DeveloperEvaluation.Domain.Entities;
using System.Security.Cryptography.X509Certificates;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public record SaleCreatedEvent(Guid Id, Guid CustomerId, Guid BrachId, decimal TotalAmount);
}
