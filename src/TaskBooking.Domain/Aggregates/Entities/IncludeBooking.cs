namespace TaskBooking.Domain.Aggregates.Entities
{
    public class IncludeBooking : Entity
    {
        protected IncludeBooking() { }
        public Guid BookingId { get; private set; }
        public TaskEventType EventType { get; private set; }
        public string Note { get; private set; }
        public EventDate EventDate { get; private set; }
        public DateTime BookingDate { get; private set; }
        public EventStatus Status { get; private set; }

        public IncludeBooking(TaskEventType eventType, DateTime bookingDate, EventStatus status)
        {
            Guard.Against.Null(eventType);
            Guard.Against.Null(bookingDate);
            Guard.Against.Null(status);           
            BookingId = Guid.NewGuid();         
            EventType = eventType;
            BookingDate = bookingDate;
            Status = status;
        }
    }
}
