using Ambev.DeveloperEvaluation.Application.Sales.Models;
using Ambev.DeveloperEvaluation.Domain.EventPublishing;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    public class GetSalesHandler(ISaleRepository repository, IEventPublisher publisher, IMapper mapper) : IRequestHandler<GetSalesCommand, GetSalesResult>
    {
        public async Task<GetSalesResult> Handle(GetSalesCommand command, CancellationToken cancellationToken)
        {
            var startDate = DateTime.Parse(command.StartDate).ToUniversalTime();
            var endDate = DateTime.Parse(command.EndDate).Date.AddDays(1).AddTicks(-1).ToUniversalTime();

            var sales = await repository.GetSalesAsync(command.CustomerId, startDate, endDate, command.PageNumber, command.PageSize, cancellationToken);

            var salesResult = mapper.Map<List<SalesDto>>(sales);

            if (sales == null || sales.Count == 0)
            {
                await publisher.PublishAsync(new SalesRetrievedEvent(command.CustomerId, startDate, endDate, command.PageNumber, command.PageSize), command.CustomerId, "No sales found for the given criteria.");
                return new GetSalesResult([]);
            }

            return new GetSalesResult(salesResult);
        }
    }
}
