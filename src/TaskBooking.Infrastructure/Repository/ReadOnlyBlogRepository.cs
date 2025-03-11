using TaskBooking.Application.Projections;
using TaskBooking.Domain.Aggregates.Enumerations;
using TaskBooking.Infrastructure.Extensions;
namespace TaskBooking.Infrastructure.Repository;

public class ReadOnlyTaskBookingRepository(TaskBookingDbContext TaskBookingDbContext,
    ILogger<ReadOnlyTaskBookingRepository> logger) : IReadOnlyBlogRepository
{
    public async Task<(IEnumerable<Client> TaskBookings, int TotalCount)> GetTaskBookings(TitleFilterModel searchModel, CancellationToken cancellationToken)
    {
        try
        {
            var query = TaskBookingDbContext.Blogs
            .AsQueryable();


            query = query.WhereIf(!string.IsNullOrEmpty(searchModel.Title), m => m.Title.Contains(searchModel.Title, StringComparison.OrdinalIgnoreCase));
            
            var totalCount = await query.AsNoTracking().CountAsync(cancellationToken);

            var TaskBookings = await query.AsNoTracking()
                .Skip((searchModel.PageNumber - 1) * searchModel.PageSize)
                .Take(searchModel.PageSize)
                .ToListAsync(cancellationToken);
            return (TaskBookings, totalCount);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "@{searchModel}", searchModel);
            throw;
        }
    }
    public async Task<bool> HasTaskBookings(Guid TaskBookingGuid, CancellationToken cancellationToken)
    {
        try
        {
            return await TaskBookingDbContext
                        .Blogs
                        .AsNoTracking()
                        .AnyAsync(x => x.BlogGuid.Equals(TaskBookingGuid)
                                && x.IsDeleted, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "{@TaskBookingGuid}", TaskBookingGuid);
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
                  .AsNoTracking()
                  .FirstOrDefaultAsync(x => x.BlogGuid.Equals(TaskBookingGuid), cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "@{TaskBookingGuid}", TaskBookingGuid);
            throw;
        }
    }
}

