namespace Application.Dto;

public record ToDoTaskDto(Guid Id, string Text, int Priority, bool IsCompleted, Guid BoardId);