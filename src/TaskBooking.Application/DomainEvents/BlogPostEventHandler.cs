namespace TaskBooking.Application.DomainEvents
{
    public class TaskBookingAddedEventHandler : INotificationHandler<TaskBookingAddedEvent>
    {
        private readonly ILogger<TaskBookingAddedEventHandler> _logger;
        private readonly IEventLogRepository _eventLogRepository;
        public TaskBookingAddedEventHandler(ILoggerFactory logger,
        IEventLogRepository eventLogRepository)
        {
            _logger = logger.CreateLogger<TaskBookingAddedEventHandler>();
            _eventLogRepository = eventLogRepository;
        }

        public async Task Handle(TaskBookingAddedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogTrace($"TaskBooking: {notification.TaskBookingGuid} has been created.");

            try
            {
                var description = $"Added:New TaskBooking {notification.Title} added";
                EventLogs eventLog = new(description, EventType.Added);
                await _eventLogRepository.AddAsync(eventLog, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{@notification}", notification);
                throw;
            }
        }
    }
    public class TaskBookingPublishedEventHandler : INotificationHandler<TaskBookingPublishedEvent>
    {
        private readonly ILogger<TaskBookingPublishedEventHandler> _logger;
        private readonly IEventLogRepository _eventLogRepository;
        public TaskBookingPublishedEventHandler(ILoggerFactory logger,
        IEventLogRepository eventLogRepository)
        {
            _logger = logger.CreateLogger<TaskBookingPublishedEventHandler>();
            _eventLogRepository = eventLogRepository;
        }

        public async Task Handle(TaskBookingPublishedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogTrace($"TaskBooking: {notification.TaskBookingGuid} has been published.");

            try
            {
                var description = $"published: {notification.Title} published";
                EventLogs eventLog = new(description, EventType.Published);
                await _eventLogRepository.AddAsync(eventLog, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{@notification}", notification);
                throw;
            }
        }
    }
}