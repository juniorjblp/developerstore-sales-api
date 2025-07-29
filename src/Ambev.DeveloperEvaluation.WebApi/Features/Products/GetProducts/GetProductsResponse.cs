using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts
{
    public record GetProductsResponse(List<Product> Products);
}
