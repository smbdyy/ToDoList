﻿using Domain.Common.Exceptions;
using Domain.Common.ValueObjects;

namespace Domain.Tasks;

public class Board : IEquatable<Board>
{
    private readonly HashSet<ToDoTask> _tasks = new ();

    public Board(Guid id, NonEmptyString name)
    {
        Id = id;
        Name = name;
    }

#pragma warning disable CS8618
    protected Board() { }
#pragma warning restore CS8618

    public Guid Id { get; protected init; }
    public NonEmptyString Name { get; set; }
    public virtual IReadOnlyCollection<ToDoTask> Tasks => _tasks;

    public void AddTask(ToDoTask task)
    {
        if (_tasks.Add(task) is false)
        {
            throw BoardException.AlreadyContainsTask(this, task);
        }
    }

    public void RemoveTask(ToDoTask task)
    {
        if (_tasks.Remove(task) is false)
        {
            throw BoardException.DoesNotContainTask(this, task);
        }
    }

    public override bool Equals(object? obj)
        => Equals(obj as Board);
    public bool Equals(Board? other)
        => other?.Id.Equals(Id) ?? false;

    public override int GetHashCode() => Id.GetHashCode();

    public override string ToString() => $"{Id.ToString()} {Name}";
}