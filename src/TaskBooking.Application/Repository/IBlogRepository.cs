namespace TaskBooking.Application.Repository;

public interface IBlogRepository : IRepository<Client>
{
    public Task<Client> AddAsync(Client TaskBookings, CancellationToken cancellationToken);
    public Task<Client> UpdateAsync(Client TaskBookings, CancellationToken cancellationToken);
    public Task<Client> GetAsync(Guid TaskBookingGuid, CancellationToken cancellationToken);
}

