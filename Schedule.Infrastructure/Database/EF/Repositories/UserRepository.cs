using Schedule.Domain.Models;
using Schedule.Domain.Repositories;
using Schedule.Infrastructure.Database.EF.Context;
using Schedule.Infrastructure.Database.EF.Entities;
using Schedule.Infrastructure.Database.EF.Extencions;
using Schedule.Infrastructure.Database.EF.Repositories.Common;

namespace Schedule.Infrastructure.Database.EF.Repositories;

public class UserRepository:GenericRepository<UserEntity>, IUserRepository
{
    private readonly ScheduleBdContext _context;

    public UserRepository(ScheduleBdContext dbContext, ScheduleBdContext context) : base(dbContext)
    {
        _context = context;
    }
    public Task<UserModel> CreateAsync(UserModel model)
    {
        if (model.Id==0)
        {
            var newEntity = model.ToEntity();
            return Task.FromResult<UserModel>(base.CreateAsync(newEntity).Result.ToModel());
        }

        var entity = model.ToEntity();
        return Task.FromResult<UserModel>(UpdateAsync(entity).Result.ToModel());
    }

    public Task<UserModel?> GetByIdAsync(int id)
    {
        var entity = base.GetByIdAsync(id).Result;
        return Task.FromResult(entity?.ToModel());
    }
    
    public new async Task<bool> DeleteHardAsync(int id)
    {
        return await base.DeleteHardAsync(id);
    }
}