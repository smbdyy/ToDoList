namespace Application.Exceptions;

public class NotFoundException : ToDoListApplicationException
{
    public NotFoundException(string? message)
        : base(message) { }

    public static NotFoundException EntityById(Guid id)
    {
        return new NotFoundException($"entity with id {id} is not found");
    }
}