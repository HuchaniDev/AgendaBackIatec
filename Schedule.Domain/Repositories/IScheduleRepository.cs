using Schedule.Domain.Dtos;
using Schedule.Domain.Models;
using Schedule.Domain.Repositories.Common;

namespace Schedule.Domain.Repositories;

public interface IScheduleRepository:IGenericRepository<ScheduleModel>
{
    public Task<List<ScheduleByUserDto>>GetSchedulesByUserAsync(int userId);
}