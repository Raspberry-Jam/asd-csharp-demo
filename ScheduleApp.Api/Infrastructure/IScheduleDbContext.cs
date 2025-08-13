using Microsoft.EntityFrameworkCore;
using ScheduleApp.Api.Models;

namespace ScheduleApp.Api.Infrastructure;

public interface IScheduleDbContext
{
    DbSet<Event> Events { get; set; }
    DbSet<Attendee> Attendees { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}