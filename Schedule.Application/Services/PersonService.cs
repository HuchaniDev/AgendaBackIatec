using System.Net;
using Schedule.Domain.Dtos;
using Schedule.Domain.Models;
using Schedule.Domain.Repositories;
using Schedule.Domain.Responses;

namespace Schedule.Application.Services;

public class PersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public Task<Result<Object>> Save(PersonModel model)
    {
        bool isSaved = (_personRepository.CreateAsync(model)) != null;
        if (isSaved)
            return Task.FromResult(Result<object>.Success(new { }, HttpStatusCode.Created));

        return Task.FromResult(Result<object>.Failure(new List<string> { "Error al guardar el usuario." },
            HttpStatusCode.BadRequest));
    }

    public Task<Result<List<PersonSummaryDto>>> SearchByName(string name)
    {
        var persons = _personRepository.GetByNameAsync(name).Result;
        if (persons.Count == 0)
            return Task.FromResult(
                Result<List<PersonSummaryDto>>.Success(new List<PersonSummaryDto>(), HttpStatusCode.NotFound));

        return Task.FromResult(Result<List<PersonSummaryDto>>.Success(persons, HttpStatusCode.OK));
    }
    
    
}