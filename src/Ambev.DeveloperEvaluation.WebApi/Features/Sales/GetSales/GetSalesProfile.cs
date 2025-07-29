using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales
{
    public class GetSalesProfile : Profile
    {
        public GetSalesProfile()
        {
            CreateMap<GetSalesRequest, GetSalesCommand>();
            CreateMap<GetSalesResult, GetSalesResponse>();
        }
    }
}
