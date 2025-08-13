namespace ScheduleApp.Api.DTOs;

public class EventDto
{
    public required string Name { get; set; }
    public required DateTime DateStart { get; set; }
    public required DateTime DateEnd { get; set; }
    public required long HourMask { get; set; }
}