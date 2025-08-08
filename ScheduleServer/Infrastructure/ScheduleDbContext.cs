using Microsoft.EntityFrameworkCore;
using ScheduleCommon.Models;

namespace ScheduleServer.Infrastructure;

public partial class ScheduleDbContext(DbContextOptions<ScheduleDbContext> options) : DbContext(options)
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
}