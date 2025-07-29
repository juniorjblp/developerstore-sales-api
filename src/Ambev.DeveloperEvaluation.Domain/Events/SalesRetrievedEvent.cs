namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public record SalesRetrievedEvent(Guid CustomerId, DateTime StartDate, DateTime EndDate, int PageNumber, int PageSize)
    {
        public string EventType => nameof(SalesRetrievedEvent);
        public string EventSource => "SalesService";
    }
}
