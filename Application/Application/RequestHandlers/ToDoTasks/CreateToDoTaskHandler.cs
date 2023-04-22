using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using Domain.Tasks;
using static Application.Contracts.ToDoTasks.CreateToDoTask;
using MediatR;

namespace Application.RequestHandlers.ToDoTasks;

internal class CreateToDoTaskHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public CreateToDoTaskHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var board = await _context.Boards.GetEntityByIdAsync(request.BoardId, cancellationToken);
        var task = new ToDoTask(Guid.NewGuid(), request.Text, (TaskPriority)request.Priority, board);

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(task.AsDto());
    }
}