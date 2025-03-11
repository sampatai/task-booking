using Microsoft.AspNet.Identity.EntityFramework;

namespace TaskBooking.Domain.Aggregates.Root
{
    public class ApplicationUser : IdentityUser, IAggregateRoot
    {

    }
}
