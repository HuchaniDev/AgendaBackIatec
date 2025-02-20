namespace Schedule.Domain.Dtos;

public record ScheduleByUserDto
(
    int Id,
    string EventName,
    string Description,
    DateTime Date,
    string Location,
    List<PersonSummaryDto> Participants
    );