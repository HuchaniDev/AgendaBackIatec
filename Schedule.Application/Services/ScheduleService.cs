using System.Net;
using Schedule.Domain.Dtos;
using Schedule.Domain.Models;
using Schedule.Domain.Repositories;
using Schedule.Domain.Responses;

namespace Schedule.Application.Services;

public class ScheduleService
{
    private readonly IScheduleRepository _scheduleRepository;

    public ScheduleService(IScheduleRepository scheduleRepository)
    {
        _scheduleRepository = scheduleRepository;
    }

    public Task<Result<Object>> Save(ScheduleModel model)
    {
        bool isSaved = (_scheduleRepository.CreateAsync(model).Result) != null;

        if (isSaved)
            return Task.FromResult(Result<object>.Success(new { }, HttpStatusCode.Created));
        
        return Task.FromResult(Result<object>.Failure(new List<string> { "Error al guardar el evento." }, HttpStatusCode.BadRequest));
    }
    
    public Task<Result<List<ScheduleByUserDto>>>GetSchedulesByUser(int userId)
    {
        var schedules = _scheduleRepository.GetSchedulesByUserAsync(userId).Result;
        if (schedules.Count == 0)
            return Task.FromResult(Result<List<ScheduleByUserDto>>.Success(new List<ScheduleByUserDto>(), HttpStatusCode.NotFound));
        
        return Task.FromResult(Result<List<ScheduleByUserDto>>.Success(schedules, HttpStatusCode.OK));
    }
    
    public Task<Result<object>>Delete(int id)
    {
        if (_scheduleRepository.DeleteHardAsync(id).Result)
            return Task.FromResult(Result<object>.Success(new { }, HttpStatusCode.OK));
        
        return Task.FromResult(Result<object>.Failure(new List<string> { "Error al eliminar el evento." }, HttpStatusCode.BadRequest));
    }
}