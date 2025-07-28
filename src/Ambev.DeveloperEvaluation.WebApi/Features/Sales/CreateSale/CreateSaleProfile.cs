using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.Models;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.Models;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Profile for mapping between Application and API CreateSale responses
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale feature
    /// </summary>
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleRequest, CreateSaleCommand>();
        CreateMap<CreateSaleItemRequest, SaleItemDto>();
        CreateMap<CreateSaleResult, CreateSaleResponse>();
        CreateMap<CreateSaleItemResult, CreateSaleItemResponse>()
            ;
    }
}
