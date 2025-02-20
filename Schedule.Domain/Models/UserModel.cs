using System.Text.Json.Serialization;

namespace Schedule.Domain.Models;

public class UserModel:BaseModel
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }

    [JsonConstructor]
    public UserModel(int id, string name, string email, string password) : base(id)
    {
        Name = name;
        Email = email;
        Password = password;
    }
}