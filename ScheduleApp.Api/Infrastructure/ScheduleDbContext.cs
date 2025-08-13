using Microsoft.EntityFrameworkCore;
using ScheduleApp.Api.Models;

namespace ScheduleApp.Api.Infrastructure;

public partial class ScheduleDbContext(DbContextOptions<ScheduleDbContext> options) : DbContext(options)
{
    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
}