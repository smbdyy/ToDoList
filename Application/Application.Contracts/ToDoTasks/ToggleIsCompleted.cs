using Application.Dto;
using MediatR;

namespace Application.Contracts.ToDoTasks;

public static class ToggleIsCompleted
{
    public record struct Command(Guid Id) : IRequest<Response>;

    public record struct Response(ToDoTaskDto ToDoTask);
}