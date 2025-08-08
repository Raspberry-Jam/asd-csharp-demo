using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleCommon.Models;
using ScheduleServer.Infrastructure;

namespace ScheduleServer.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController(ILogger<EventController> log, IScheduleDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Event>> GetListOfEvents()
    {
        return await db.Events.ToListAsync();
    }

    [HttpPost]
    public async Task AddEvent([FromBody] Event newEvent)
    {
        await db.Events.AddAsync(newEvent);
        await db.SaveChangesAsync();
    }
}