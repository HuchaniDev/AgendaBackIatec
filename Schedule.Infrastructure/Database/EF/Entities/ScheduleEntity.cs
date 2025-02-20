using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schedule.Infrastructure.Database.EF.Entities;

[Table("schedule", Schema = "SCH")]
public class ScheduleEntity : BaseEntity, IIdentifiable
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("eventName")]
    [StringLength(25)]
    [Required]
    public string EventName { get; set; }

    [Column("description")]
    [StringLength(200)]
    [Required]
    public string Description { get; set; }

    [Required] 
    public DateTime Date { get; set; }

    [Column("location")]
    [StringLength(50)]
    public string Location { get; set; }
    
    [Column("userId")]
    public int UserId { get; set; }
    
    [ForeignKey("UserId")]
    public UserEntity User { get; set; }
    
    public virtual ICollection<PersonEntity>Partcipantes { get; set; }
    
}