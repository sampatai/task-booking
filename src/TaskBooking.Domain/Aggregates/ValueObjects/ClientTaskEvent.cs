using System;
namespace TaskBooking.Domain.Aggregates.ValueObjects
{
    public class ClientTaskEvent
    {
        public long TaskEventId { get; private set; }
    }
}
