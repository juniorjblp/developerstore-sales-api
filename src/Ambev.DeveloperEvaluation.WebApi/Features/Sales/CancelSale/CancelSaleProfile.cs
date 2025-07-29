using Ambev.DeveloperEvaluation.Application.Sales.CancelSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CancelSale
{
    public class CancelSaleProfile : Profile
    {
        public CancelSaleProfile() 
        {
            CreateMap<CancelSaleRequest, CancelSaleCommand>();
            CreateMap<CancelSaleResult, CancelSaleResponse>();
        }
    }
}
