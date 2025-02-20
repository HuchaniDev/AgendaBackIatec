using System.Text.Json.Serialization;

namespace Schedule.Domain.Models;

public class PersonModel:BaseModel
{

    public string Name { get; private set; }

    public string LastName { get; private set; }

    public int Ci { get; private set; }

    public string Phone { get; private set; }

    public int ScheduleId { get; private set; }

    [JsonConstructor]
    public PersonModel(int id, string name, string lastName, int ci, string phone, int scheduleId) : base(id)
    {
        Name = name;
        LastName = lastName;
        Ci = ci;
        Phone = phone;
        ScheduleId = scheduleId;
    }
}