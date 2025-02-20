namespace Schedule.Infrastructure.Database.EF.Entities;

public abstract class BaseEntity
{
    public DateTime CreatedAt { get; set; }
    public int CreatedBy { get; set; }
    public DateTime LastModifiedByAt { get; set; }
    public int LastModifiedBy { get; set; }
}