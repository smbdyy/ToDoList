using MediatR;

namespace Application.Contracts.ToDoTasks;

public static class DeleteToDoTask
{
    public record struct Command(Guid Id) : IRequest;
}