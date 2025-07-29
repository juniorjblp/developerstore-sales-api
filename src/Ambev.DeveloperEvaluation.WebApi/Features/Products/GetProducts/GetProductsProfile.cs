using Ambev.DeveloperEvaluation.Application.Products;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts
{
    public class GetProductsProfile : Profile
    {
        public GetProductsProfile() 
        {
            CreateMap<GetProductsResult, GetProductsResponse>();
            CreateMap<GetProductsRequest, GetProductsCommand>();
        }
    }
}
