using Microsoft.AspNetCore.Mvc;
using ScheduleApp.Api.DTOs;
using ScheduleApp.Api.Infrastructure;
using ScheduleApp.Api.Models;

namespace ScheduleApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AttendanceController(ILogger<AttendanceController> log, IScheduleDbContext db) : ControllerBase
{
    [HttpPost("add")]
    public async Task<ActionResult> AddAttendanceToEvent([FromBody] AttendeeDto bodyVar)
    {
        var attendee = new Attendee
        {
            Id = default,
            Name = bodyVar.Name,
            HourMask = bodyVar.HourMask,
            EventId = bodyVar.EventId,
        };
        
        await db.Attendees.AddAsync(attendee);
        await db.SaveChangesAsync();
        return Created();
    }
}