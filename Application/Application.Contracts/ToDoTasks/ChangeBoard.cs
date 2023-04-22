using Application.Dto;
using MediatR;

namespace Application.Contracts.ToDoTasks;

public static class ChangeBoard
{
    public record struct Command(Guid TaskId, Guid NewBoardId) : IRequest<Response>;

    public record struct Response(ToDoTaskDto ToDoTask);
}