using Schedule.Application.Services;
using Schedule.Domain.Models;

namespace Schedule.Api.Endpoints;

internal static class UserEndpoints
{
    internal static void MapUserEndpoints(this WebApplication WebApp)
    {
        WebApp.MapGroup("/iatec").WithTags("User").MapGroupEndPoint();
    }

    private static void MapGroupEndPoint(this RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost(
            "/",
            (UserModel user,UserService userService) =>
            {
                var result = userService.Save(user).Result;
                return Results.Json(result, statusCode:(int)result.StatusCode);
            });
    }
}