using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Sales.Models;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Sale>();
        CreateMap<SaleItemDto, SaleItem>();
        CreateMap<SaleItem, CreateSaleItemResult>();
        CreateMap<Sale, CreateSaleResult>()
            .ForMember(dest => dest.SaleNumber, opt =>
                opt.MapFrom(src => src.FormattedSaleNumber))
            .ForMember(dest => dest.Total, opt =>
                opt.MapFrom(src => src.TotalAmount))
            .ForMember(dest => dest.Discount, opt => 
                opt.MapFrom(src => src.TotalDiscount));
    }
}
