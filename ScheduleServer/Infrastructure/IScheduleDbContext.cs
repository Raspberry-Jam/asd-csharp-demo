using Microsoft.EntityFrameworkCore;
using ScheduleCommon.Models;

namespace ScheduleServer.Infrastructure;

public interface IScheduleDbContext
{
    DbSet<Event> Events { get; set; }
    DbSet<Attendee> Attendees { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}