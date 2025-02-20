using Schedule.Domain.Models;
using Schedule.Infrastructure.Database.EF.Entities;

namespace Schedule.Infrastructure.Database.EF.Extencions;

public static class PersonExtencion
{
    public static PersonEntity ToEntity(this PersonModel model)
    {
        return new PersonEntity
        {
            Id = model.Id,
            Name = model.Name,
            LastName = model.LastName,
            Ci = model.Ci,
            Phone = model.Phone,
            ScheduleId = model.ScheduleId
        };
    }
    
    public static PersonModel ToModel(this PersonEntity entity)
    {
        return new PersonModel(
            entity.Id, 
            entity.Name,
            entity.LastName, 
            entity.Ci, 
            entity.Phone,
            entity.ScheduleId
            );
    }
    
    
}