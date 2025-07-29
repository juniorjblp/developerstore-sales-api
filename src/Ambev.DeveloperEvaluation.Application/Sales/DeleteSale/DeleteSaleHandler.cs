using Ambev.DeveloperEvaluation.Domain.EventPublishing;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleHandler(ISaleRepository repository, IEventPublisher publisher) : IRequestHandler<DeleteSaleCommand, DeleteSaleResult>
    {
        public async Task<DeleteSaleResult> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await repository.GetSaleByIdAsync(request.Id) ?? throw new NotFoundException($"Sale with ID {request.Id} not found.");

            sale.Delete();

            await repository.UpdateSaleAsync(sale, cancellationToken);

            await publisher.PublishAsync(new SaleDeletedEvent(sale.Id), sale.Id, $"Sale id: {sale.Id} deleted");

            return new DeleteSaleResult(sale.Id, true);
        }
    }
}
