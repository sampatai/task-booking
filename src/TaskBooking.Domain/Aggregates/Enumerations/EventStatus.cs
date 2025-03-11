using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBooking.Domain.Aggregates.Enumerations
{
  
    public class EventStatus : Enumeration
    {
        public static EventStatus Pending = new(1, nameof(Pending));
        public static EventStatus Scheduled = new(2, nameof(Scheduled));
        public static EventStatus Cancelled = new(3, nameof(Cancelled));
        public static EventStatus ReScheduled = new(4, "Re-Scheduled");
        public EventStatus(int id, string name) : base(id, name)
        {
        }
    }
}
