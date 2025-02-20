using Microsoft.EntityFrameworkCore;
using Schedule.Domain.Dtos;
using Schedule.Domain.Models;
using Schedule.Domain.Repositories;
using Schedule.Infrastructure.Database.EF.Context;
using Schedule.Infrastructure.Database.EF.Entities;
using Schedule.Infrastructure.Database.EF.Extencions;
using Schedule.Infrastructure.Database.EF.Repositories.Common;

namespace Schedule.Infrastructure.Database.EF.Repositories;

public class ScheduleRepository:GenericRepository<ScheduleEntity>,IScheduleRepository
{
    private readonly ScheduleBdContext _dbContext;
    public ScheduleRepository(ScheduleBdContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<ScheduleModel> CreateAsync(ScheduleModel model)
    {
        if (model.Id == 0)
        {
            var newEntity = model.ToEntity();
            return Task.FromResult(base.CreateAsync(newEntity).Result.ToModel());
        }
        
        var entity =  model.ToEntity();
        return Task.FromResult(UpdateAsync(entity).Result.ToModel());
    }

    public Task<ScheduleModel?> GetByIdAsync(int id)
    {
        var entity = base.GetByIdAsync(id).Result;
        return Task.FromResult(entity?.ToModel());
    }
    
    public new async Task<bool> DeleteHardAsync(int id)
    {
        return await base.DeleteHardAsync(id);
    }

    public async Task<List<ScheduleByUserDto>> GetSchedulesByUserAsync(int userId)
    {
        var query = await _dbContext.Schedule
            .Where(s => s.UserId == userId)
            .Include(s=>s.Partcipantes)
            .Select(s => new ScheduleByUserDto(
                s.Id,
                s.EventName,
                s.Description,
                s.Date,
                s.Location,
                s.Partcipantes.Select(p=>
                        new PersonSummaryDto(
                                p.Id,
                                p.Name,
                                p.LastName,
                                p.Ci
                                ))
                    .ToList()))
            .ToListAsync();


        return query;
    }
}