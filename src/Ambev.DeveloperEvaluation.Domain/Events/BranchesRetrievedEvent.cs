using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public record BranchesRetrievedEvent(int PageNumber, int PageSize);
}
