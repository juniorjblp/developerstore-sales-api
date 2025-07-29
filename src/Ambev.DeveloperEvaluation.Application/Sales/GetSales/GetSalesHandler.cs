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
        public async Task<GetSalesResult> Handle(GetSalesCommand request, CancellationToken cancellationToken)
        {
            var sales = await repository.GetSalesAsync(request.CustomerId, request.StartDate, request.EndDate, request.PageNumber, request.PageSize, cancellationToken);

            var salesResult = mapper.Map<List<SalesDto>>(sales);

            if (sales == null || sales.Count == 0)
            {
                await publisher.PublishAsync(new SalesRetrievedEvent(request.CustomerId, request.StartDate, request.EndDate, request.PageNumber, request.PageSize), request.CustomerId, "No sales found for the given criteria.");
                return new GetSalesResult([]);
            }

            return new GetSalesResult(salesResult);
        }
    }
}
