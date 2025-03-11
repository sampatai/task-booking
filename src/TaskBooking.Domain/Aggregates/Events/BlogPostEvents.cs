namespace TaskBooking.Domain.Aggregates.Events;

public record TaskBookingAddedEvent(Guid TaskBookingGuid, string Title) : INotification { }
public record TaskBookingPublishedEvent(Guid TaskBookingGuid, string Title) : INotification { }
