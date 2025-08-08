namespace ScheduleCommon.Models;

public class Attendee
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required long HourMask { get; set; }
    
    // Foreign keys
    public required int EventId { get; set; }
    
    // Navigation properties
    public required Event Event { get; set; }
}