namespace TaskBooking.Infrastructure.Repository;

public class EventLogRepository(TaskBookingDbContext TaskBookingDbContext,
    ILogger<EventLogRepository> logger) : IEventLogRepository
{
    public IUnitOfWork UnitOfWork => TaskBookingDbContext;

    public async Task<EventLogs> AddAsync(EventLogs eventLogs, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await TaskBookingDbContext.EventLogs.AddAsync(eventLogs);
            return entity.Entity;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "@{eventLogs}", eventLogs);
            throw;
        }
    }
}

