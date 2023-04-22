using Application.Abstractions.DataAccess;
using Application.Extensions;
using static Application.Contracts.ToDoTasks.DeleteToDoTask;
using MediatR;

namespace Application.RequestHandlers.ToDoTasks;

internal class DeleteToDoTaskHandler : IRequestHandler<Command>
{
    private readonly IDatabaseContext _context;

    public DeleteToDoTaskHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task Handle(Command request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks.GetEntityByIdAsync(request.Id, cancellationToken);
        task.Board.RemoveTask(task);

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync(cancellationToken);
    }
}