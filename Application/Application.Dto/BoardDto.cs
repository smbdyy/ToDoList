namespace Application.Dto;

public record BoardDto(Guid Id, string Name, IReadOnlyCollection<ToDoTaskDto> Tasks);