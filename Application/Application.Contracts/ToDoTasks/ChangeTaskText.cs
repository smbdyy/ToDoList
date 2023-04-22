using Application.Dto;
using MediatR;

namespace Application.Contracts.ToDoTasks;

public static class ChangeTaskText
{
    public record struct Command(Guid Id, string NewText) : IRequest<Response>;

    public record struct Response(ToDoTaskDto ToDoTask);
}