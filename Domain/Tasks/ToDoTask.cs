using Domain.Common.Exceptions;
using Domain.Common.ValueObjects;

namespace Domain.Tasks;

public class ToDoTask : IEquatable<ToDoTask>
{
    public ToDoTask(Guid id, NonEmptyString text, TaskPriority priority, Board board)
    {
        Id = id;
        Text = text;
        Priority = priority;
        Board = board;
        IsCompleted = false;
    }

#pragma warning disable CS8618
    protected ToDoTask() { }
#pragma warning restore CS8618

    public Guid Id { get; protected init;  }
    public NonEmptyString Text { get; set; }
    public TaskPriority Priority { get; set; }
    public bool IsCompleted { get; private set; }
    public virtual Board Board { get; private set; }

    public void MoveToBoard(Board newBoard)
    {
        if (newBoard.Equals(Board))
        {
            throw BoardException.AlreadyContainsTask(newBoard, this);
        }

        Board.RemoveTask(this);
        newBoard.AddTask(this);
        Board = newBoard;
    }

    public void ToggleIsCompleted()
    {
        IsCompleted = !IsCompleted;
    }

    public override bool Equals(object? obj)
        => Equals(obj as ToDoTask);
    public bool Equals(ToDoTask? other)
        => other?.Id.Equals(Id) ?? false;

    public override int GetHashCode() => Id.GetHashCode();
    public override string ToString() => $"{Id.ToString()} {Text}";
}