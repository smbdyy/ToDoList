namespace Domain.Common.Exceptions;

public class IncorrectValueException : ToDoListDomainException
{
    public IncorrectValueException(string? message)
        : base(message) { }

    public static IncorrectValueException EmptyString()
    {
        return new IncorrectValueException("string must not be empty");
    }
}