using Schedule.Application.Services;
using Schedule.Domain.Models;

namespace Schedule.Api.Endpoints;

internal static class ScheduleEndpoints
{
    internal static void MapScheduleEndpoints(this WebApplication webApp)
    {
        webApp.MapGroup("/schedules").WithTags("SCH - Horarios").MapGroupEndPoint();
    }

    private static void MapGroupEndPoint(this RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost(
            "/",
            (ScheduleModel model, ScheduleService scheduleService) =>
            {
                var result = scheduleService.Save(model).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        
        groupBuilder.MapGet(
            "by-user/{UserId:int}",
            (ScheduleService scheduleService, int UserId) =>
            {
                var result = scheduleService.GetSchedulesByUser(UserId).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
        
        groupBuilder.MapDelete(
            "/{eventId:int}",
            (ScheduleService scheduleService, int eventId) =>
            {
                var result = scheduleService.Delete(eventId).Result;
                return Results.Json(result, statusCode: (int)result.StatusCode);
            });
    }
    
}