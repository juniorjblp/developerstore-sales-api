using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.EventPublishing;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class CreateSaleHandler(ISaleRepository saleRepository, IBranchRepository branchRepository, IProductRepository productRepository, IUser user, IMapper mapper, IEventPublisher publisher) : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    /// <summary>
    /// Handles the CreateSaleCommand request
    /// </summary>
    /// <param name="command">The CreateSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created Sale details</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        if (!Guid.TryParse(user.Id, out Guid userId))
            throw new ValidationException("Invalid user ID format.");

        if (string.IsNullOrWhiteSpace(user.Username))
            throw new ValidationException("Invalid user name format.");

        var branch = await branchRepository.GetByIdAsync(command.BranchId, cancellationToken) ?? throw new ValidationException("Branch not found.");

        var productIds = command.Items.Select(i => i.ProductId).ToList();
        var products = await productRepository.GetByIdsAsync(productIds);

        var saleItems = new List<SaleItem>();
        foreach (var itemDto in command.Items)
        {
            var product = products.FirstOrDefault(p => p.Id == itemDto.ProductId) ?? throw new NotFoundException($"Product {itemDto.ProductId} not found.");
            var saleItem = SaleItem.Create(product, itemDto.Quantity);
            saleItems.Add(saleItem);
        }

        var sale = Sale.Create(userId, user.Username, branch, saleItems);

        var createdSale = await saleRepository.CreateAsync(sale, cancellationToken);

        await publisher.PublishAsync(new SaleCreatedEvent(createdSale.Id, createdSale.CustomerId, createdSale.BranchId, createdSale.TotalAmount), createdSale.Id, $"Sale id:{createdSale.Id} created");

        var result = mapper.Map<CreateSaleResult>(createdSale);
        return result;
    }
}
