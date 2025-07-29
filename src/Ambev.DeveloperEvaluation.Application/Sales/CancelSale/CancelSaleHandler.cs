using Ambev.DeveloperEvaluation.Domain.EventPublishing;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CancelSale
{
    public class CancelSaleHandler(ISaleRepository repository, IEventPublisher publisher) : IRequestHandler<CancelSaleCommand, CancelSaleResult>
    {
        public async Task<CancelSaleResult> Handle(CancelSaleCommand command, CancellationToken cancellationToken)
        {
            var sale = await repository.GetSaleByIdAsync(command.Id) ?? throw new NotFoundException($"Sale with ID {command.Id} not found.");
            if (sale.IsCancelled)
                throw new InvalidOperationException($"Sale with ID {command.Id} is already cancelled.");

            sale.Cancel();

            await repository.UpdateSaleAsync(sale, cancellationToken);

            await publisher.PublishAsync(new SaleCancelledEvent(sale.Id), sale.Id, $"Sale id: {sale.Id} cancelled");

            return new CancelSaleResult(sale.Id, true);
        }
    }
}
