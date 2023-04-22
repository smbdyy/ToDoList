using Application.Dto;
using MediatR;

namespace Application.Contracts.ToDoTasks;

public static class CreateToDoTask
{
    public record struct Command(string Text, int Priority, Guid BoardId) : IRequest<Response>;

    public record struct Response(ToDoTaskDto ToDoTask);
}