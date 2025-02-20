using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schedule.Infrastructure.Database.EF.Entities;

[Table("Person", Schema = "SCH")]
public class PersonEntity:BaseEntity, IIdentifiable
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("lastName")]
    public string LastName { get; set; }
    
    [Required]
    [Column("ci")]
    public int Ci { get; set; }
    
    [Column("phone")]
    public string Phone { get; set; }
    
    [Column("scheduleId")]
    public int ScheduleId { get; set; }
    
    [ForeignKey("ScheduleId")]
    public ScheduleEntity Schedule { get; set; }

}