namespace ScheduleApp.Api.DTOs;

public class AttendeeDto
{
    public required string Name { get; set; }
    public required long HourMask { get; set; }
    public required int EventId { get; set; }
}