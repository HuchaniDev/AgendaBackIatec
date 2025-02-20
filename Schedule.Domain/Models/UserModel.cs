using System.Text.Json.Serialization;

namespace Schedule.Domain.Models;

public class UserModel:BaseModel
{
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public int Ci { get; private set; }
    public string Password { get; private set; }

    [JsonConstructor]
    public UserModel(int id, string name, string lastName, string email, int ci, string password) : base(id)
    {
        Name = name;
        LastName = lastName;
        Email = email;
        Ci = ci;
        Password = password;
    }
}