using Schedule.Application.Services;
using Schedule.Domain.Models;

namespace Schedule.Api.Endpoints;

internal static class PersonEndpoints
{

    internal static void MapPersonEndpoints(this WebApplication webApp)
    {
        webApp.MapGroup("/persons").WithTags("Persons").MapGroupEndPoint();
    }

    private static void MapGroupEndPoint(this RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost(
            "/",
            (PersonModel model, PersonService personService) =>
            {
                var result = personService.Save(model).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });

        groupBuilder.MapGet(
            "/by-name",
            (PersonService personService, string name) =>
            {
                var result = personService.SearchByName(name).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
    }
}