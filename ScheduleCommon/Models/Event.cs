namespace ScheduleCommon.Models;

public class Event
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required DateTime DateStart { get; set; }
    public required DateTime DateEnd { get; set; }
    public required long HourMask { get; set; }
    
    // Foreign keys
    
    // Navigation properties
    public ICollection<Attendee> Attendees { get; set; } = new List<Attendee>();
}