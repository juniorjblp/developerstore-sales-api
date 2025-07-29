using Ambev.DeveloperEvaluation.Domain.EventPublishing;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.GetBranches
{
    public class GetBranchesHandler(IBranchRepository repository, IEventPublisher publisher) : IRequestHandler<GetBranchesCommand, GetBranchesResult>
    {
        public async Task<GetBranchesResult> Handle(GetBranchesCommand command, CancellationToken cancellationToken)
        {
            var branches = await repository.GetBranchesAsync(command.PageNumber, command.PageSize, cancellationToken);

            if (branches == null || branches.Count == 0)
            {
                await publisher.PublishAsync(new BranchesRetrievedEvent(command.PageNumber, command.PageSize), Guid.NewGuid(), "No branches found for the given criteria.");
                return new GetBranchesResult([]);
            }
            return new GetBranchesResult(branches);
        }
    }
}
