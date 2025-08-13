using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScheduleApp.Api.DTOs;
using ScheduleApp.Api.Infrastructure;
using ScheduleApp.Api.Models;

namespace ScheduleApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController(ILogger<EventController> log, IScheduleDbContext db) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Event>>> GetListOfEvents()
    {
        return Ok(await db.Events.ToListAsync()); // 200
    }

    [HttpPost("create")]
    public async Task<ActionResult> AddEvent([FromBody] EventDto newEvent)
    {
        // TODO: Error handling
        var dbEvent = new Event
        {
            Name = newEvent.Name, 
            DateStart = newEvent.DateStart, 
            DateEnd = newEvent.DateEnd,
            HourMask = newEvent.HourMask
        };
        await db.Events.AddAsync(dbEvent);
        await db.SaveChangesAsync();
        log.LogInformation("Created new event \"{NewEventName}\"", dbEvent.Name);
        return Created(); // 201
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Event>> GetEvent(int id)
    {
        var query = from e in db.Events
            where e.Id == id
            select e;

        if (!await query.AnyAsync())
        {
            log.LogWarning("Could not find event \"{EventId}\"", id);
            return NotFound();
        }
        return Ok(await query.FirstAsync()); // 200
    }

    [HttpGet("delete/{id:int}")]
    public async Task<ActionResult> DeleteEvent(int id)
    {
        // Query by ID to ensure no weird false object equality
        var query =
            from e in db.Events
            where e.Id == id
            select e;
        
        if (!await query.AnyAsync()) return BadRequest();
        
        var eventToDelete = await query.FirstAsync();
        db.Events.Remove(eventToDelete);
        await db.SaveChangesAsync();
        log.LogInformation("Deleted event \"{EventName}\"", eventToDelete.Name);

        return NoContent(); // 204
    }
}