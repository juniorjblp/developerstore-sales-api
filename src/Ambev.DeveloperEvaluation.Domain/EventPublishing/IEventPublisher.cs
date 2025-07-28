namespace Ambev.DeveloperEvaluation.Domain.EventPublishing
{
    public interface IEventPublisher
    {
        Task PublishAsync<T>(T message, Guid entityId, string eventname);
    }
}
