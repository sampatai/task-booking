namespace TaskBooking.Application.Repository;

public interface IReadOnlyBlogRepository : IReadOnlyRepository<Client>
{
    public Task<(IEnumerable<Client> TaskBookings, int TotalCount)> GetTaskBookings(TitleFilterModel searchModel,CancellationToken cancellationToken);
    public Task<bool> HasTaskBookings(Guid TaskBookingGuid,CancellationToken cancellationToken);
    Task<Client> GetAsync(Guid TaskBookingGuid, CancellationToken cancellationToken);
}

