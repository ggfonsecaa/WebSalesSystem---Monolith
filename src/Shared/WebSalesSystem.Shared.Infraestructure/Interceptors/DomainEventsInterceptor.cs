namespace WebSalesSystem.Shared.Infraestructure.Interceptors;
public class DomainEventsInterceptor(IPublisher publisher, ILogger<DomainEventsInterceptor> logger) : SaveChangesInterceptor
{
    private readonly IPublisher _publisher = publisher;
    private readonly ILogger<DomainEventsInterceptor> _logger = logger;

    public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        if (result != 0)
        {
            DomainEvent[]? events = eventData.Context!.ChangeTracker.Entries<Entity>()
                    .SelectMany(x => x.Entity.DomainEvents!)
                    .Where(domainEvent => !domainEvent.IsPublished)
                    .ToArray();

            foreach (DomainEvent @event in events)
            {
                @event.Publish();
                _logger.LogInformation("New domain event {Event}", @event.GetType().Name);

                await _publisher.Publish(@event, cancellationToken);
            }
        }

        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }
}