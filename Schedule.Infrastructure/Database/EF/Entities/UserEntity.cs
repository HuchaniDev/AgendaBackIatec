﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Schedule.Infrastructure.Database.EF.Entities;
[Table("User", Schema = "SCH")]
public class UserEntity:BaseEntity, IIdentifiable
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    
    [Required]
    [Column("name")]
    [StringLength(25)]
    public string Name { get; set; }
    
    
    [Required]
    [Column("email")]
    [StringLength(30)]
    public string Email { get; set; }
    

    
    [Required]
    [Column("password")]
    public string Password { get; set; }
    
    public virtual ICollection<ScheduleEntity> Schedules { get; set; }
    
}