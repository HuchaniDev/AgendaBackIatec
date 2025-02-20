using Schedule.Domain.Models;
using Schedule.Infrastructure.Database.EF.Entities;

namespace Schedule.Infrastructure.Database.EF.Extencions;

public static class ScheduleExtencion
{
    
    public static ScheduleEntity ToEntity(this ScheduleModel model)
    {
        return new ScheduleEntity
        {
            Id = model.Id,
            EventName = model.EventName,
            Description = model.Description,
            Date = model.Date,
            Location = model.Location,
            UserId = model.UserId
        };
    }
    
    public static ScheduleModel ToModel(this ScheduleEntity entity)
    {
        return new ScheduleModel(
            entity.Id, 
            entity.EventName, 
            entity.Description,
            entity.Date,
            entity.Location, 
            entity.UserId);
    }
}