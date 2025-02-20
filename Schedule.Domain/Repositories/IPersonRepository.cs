using Schedule.Domain.Dtos;
using Schedule.Domain.Models;
using Schedule.Domain.Repositories.Common;

namespace Schedule.Domain.Repositories;

public interface IPersonRepository:IGenericRepository<PersonModel>
{
    public Task<List<PersonSummaryDto>>GetByNameAsync(string name);
    
}