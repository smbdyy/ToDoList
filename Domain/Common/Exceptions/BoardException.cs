using Domain.Tasks;

namespace Domain.Common.Exceptions;

public class BoardException : ToDoListDomainException
{
    public BoardException(string? message)
        : base(message) { }

    public static BoardException AlreadyContainsTask(Board board, ToDoTask task)
    {
        return new BoardException($"board {board} already contains task {task}");
    }

    public static BoardException DoesNotContainTask(Board board, ToDoTask task)
    {
        return new BoardException($"board {board} does not contain task {task}");
    }
}