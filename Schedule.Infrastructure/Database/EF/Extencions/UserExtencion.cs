﻿using Schedule.Domain.Models;
using Schedule.Infrastructure.Database.EF.Entities;

namespace Schedule.Infrastructure.Database.EF.Extencions;

public static class UserExtencion
{
    public static UserEntity ToEntity(this UserModel model)
    {
        return new UserEntity
        {
            Id = model.Id,
            Name = model.Name,
            Email = model.Email,
            Password = model.Password,
        };
    }
    
    public static UserModel ToModel(this UserEntity entity)
    {
        return new UserModel(entity.Id, entity.Name, entity.Email, entity.Password);
    }
}