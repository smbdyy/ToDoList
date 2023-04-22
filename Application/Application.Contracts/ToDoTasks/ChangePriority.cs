using Application.Dto;
using MediatR;

namespace Application.Contracts.ToDoTasks;

public static class ChangePriority
{
    public record struct Command(Guid Id, int NewPriority) : IRequest<Response>;

    public record struct Response(ToDoTaskDto ToDoTask);
}