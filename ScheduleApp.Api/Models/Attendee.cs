namespace ScheduleApp.Api.Models;

public class Attendee
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required long HourMask { get; set; }
    
    // Foreign keys
    public required int EventId { get; set; }
    
    // Navigation properties
    public virtual Event Event { get; set; } = default!;
}