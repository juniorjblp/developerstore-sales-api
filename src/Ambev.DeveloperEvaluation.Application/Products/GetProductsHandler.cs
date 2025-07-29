using Ambev.DeveloperEvaluation.Domain.EventPublishing;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products
{
    public class GetProductsHandler(IProductRepository repository, IEventPublisher publisher) : IRequestHandler<GetProductsCommand, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsCommand request, CancellationToken cancellationToken)
        {
            var products = await repository.GetProductsAsync(request.PageNumber, request.PageSize, cancellationToken);

            if (products == null || products.Count == 0)
            {
                await publisher.PublishAsync(new ProductsRetrievedEvent(request.PageNumber, request.PageSize), Guid.NewGuid(), "No products found for the given criteria.");
                return new GetProductsResult([]);
            }

            return new GetProductsResult(products);
        }
    }
}
