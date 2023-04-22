namespace Application.Exceptions;

public class ToDoListApplicationException : Exception
{
    public ToDoListApplicationException(string? message)
        : base(message) { }
}