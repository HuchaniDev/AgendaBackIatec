using System.ComponentModel.DataAnnotations.Schema;

namespace Schedule.Infrastructure.Database.EF.Entities;

[Table("schedule", Schema = "SCH")]
public class scheduleEntity : BaseEntity, IIdentifiable
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
}