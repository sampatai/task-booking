namespace TaskBooking.Infrastructure.Repository;

public class BlogRepository(TaskBookingDbContext TaskBookingDbContext,
    ILogger<BlogRepository> logger) : IBlogRepository
{
    public IUnitOfWork UnitOfWork => TaskBookingDbContext;

    public async Task<Client> AddAsync(Client TaskBookings, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await TaskBookingDbContext.Blogs.AddAsync(TaskBookings);
            return entity.Entity;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "@{TaskBookings}", TaskBookings);
            throw;
        }
    }

    public async Task<Client> GetAsync(Guid TaskBookingGuid, CancellationToken cancellationToken)
    {
        try
        {
            return await TaskBookingDbContext
                  .Blogs
                  .Include(x => x.Images)
                  .Include(x => x.CategoryIds)
                  .AsTracking()
                  .FirstOrDefaultAsync(x => x.BlogGuid.Equals(TaskBookingGuid), cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "@{TaskBookingGuid}", TaskBookingGuid);
            throw;
        }
    }

    public async Task<Client> UpdateAsync(Client TaskBookings, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await Task.FromResult(TaskBookingDbContext.Blogs.Update(TaskBookings));
            return entity.Entity;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "@{TaskBookings}", TaskBookings);
            throw;
        }
    }
}

