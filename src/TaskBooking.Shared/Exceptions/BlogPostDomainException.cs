namespace TaskBooking.Shared.Exceptions;
  
public class TaskBookingDomainException : Exception
{
    public TaskBookingDomainException()
    { }

    public TaskBookingDomainException(string message)
        : base(message)
    { }

    public TaskBookingDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}

