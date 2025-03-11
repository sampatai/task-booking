
namespace TaskBooking.Domain.Aggregates.Root
{

    public class Booking : Entity, IAggregateRoot
    {

        protected Booking(){}
        public Guid BookingId { get; private set; }
        public TaskEventType EventType { get; private set; }
        public string Note { get; private set; }
        public EventDate EventDate { get; private set; }
        public DateTime BookingDate { get; private set; }
        public EventStatus Status { get; private set; }
        public long UserId { get; private set; }
      
        private List<Booking> _bookings;
        private List<Feedback> _feedbacks;

        public IReadOnlyCollection<Booking> Bookings => _bookings.AsReadOnly();
        public IReadOnlyCollection<Feedback> Feedbacks => _feedbacks.AsReadOnly();

        public Booking(TaskEventType eventType, EventDate eventDate, List<string> requiredItems,long userId)
        {
          
           
            _bookings = new List<Booking>();
            _feedbacks = new List<Feedback>();
        }

        public void BookPuja(long clientId, DateTime bookingDate)
        {
            var booking = new Entities.Booking(clientId, bookingDate, EventStatus.Pending);
            _bookings.Add(booking);
        }

        public void ProvideFeedback(Guid clientId, string comments, int rating)
        {
            var feedback = new Feedback(clientId, EventId, comments, rating);
            _feedbacks.Add(feedback);
        }
    }

}
}
