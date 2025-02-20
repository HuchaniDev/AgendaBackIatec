using System.Text.Json.Serialization;

namespace Schedule.Domain.Models;

public class ScheduleModel: BaseModel
{
    public string EventName { get; private set; }
    public string Description { get; private set; }
    public DateTime Date { get; private set; }
    public string Location { get; private set; }
    public int UserId { get; private set; }

    [JsonConstructor]
    public ScheduleModel(int id, string eventName, string description, DateTime date, string location, int userId) : base(id)
    {
        EventName = eventName;
        Description = description;
        Date = date;
        Location = location;
        UserId = userId;
    }
}