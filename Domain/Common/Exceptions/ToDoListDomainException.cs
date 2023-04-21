namespace Domain.Common.Exceptions;

public class ToDoListDomainException : Exception
{
    public ToDoListDomainException(string? message)
        : base(message) { }
}