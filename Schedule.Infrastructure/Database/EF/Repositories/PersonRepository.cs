using Microsoft.EntityFrameworkCore;
using Schedule.Domain.Dtos;
using Schedule.Domain.Models;
using Schedule.Domain.Repositories;
using Schedule.Infrastructure.Database.EF.Context;
using Schedule.Infrastructure.Database.EF.Entities;
using Schedule.Infrastructure.Database.EF.Extencions;
using Schedule.Infrastructure.Database.EF.Repositories.Common;

namespace Schedule.Infrastructure.Database.EF.Repositories;

public class PersonRepository:GenericRepository<PersonEntity>, IPersonRepository
{
    private readonly ScheduleBdContext _dbContext;

    public PersonRepository(ScheduleBdContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<PersonModel> CreateAsync(PersonModel model)
    {
        if (model.Id == 0)
        {
            var newEntity = model.ToEntity();
            return Task.FromResult(base.CreateAsync(newEntity).Result.ToModel());
        }
        
        var entity =  model.ToEntity();
        return Task.FromResult(UpdateAsync(entity).Result.ToModel());
    }

    public Task<PersonModel?> GetByIdAsync(int id)
    {
        var entity = base.GetByIdAsync(id).Result;
        return Task.FromResult(entity?.ToModel());
    }
    
    public new async Task<bool> DeleteHardAsync(int id)
    {
        return await base.DeleteHardAsync(id);
    }

    public async Task<List<PersonSummaryDto>> GetByNameAsync(string name)
    {
        var persons = await _dbContext.Person
            .Where(p => p.Name.Contains(name))
            .Select(p => new PersonSummaryDto(
                p.Id, 
                p.Name, 
                p.LastName,
                p.Ci
                ))
            .ToListAsync();

        return persons;
    }
}