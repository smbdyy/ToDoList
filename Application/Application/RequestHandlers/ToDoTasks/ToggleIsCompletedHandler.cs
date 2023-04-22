using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using static Application.Contracts.ToDoTasks.ToggleIsCompleted;
using MediatR;

namespace Application.RequestHandlers.ToDoTasks;

internal class ToggleIsCompletedHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public ToggleIsCompletedHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks.GetEntityByIdAsync(request.Id, cancellationToken);

        task.ToggleIsCompleted();
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(task.AsDto());
    }
}