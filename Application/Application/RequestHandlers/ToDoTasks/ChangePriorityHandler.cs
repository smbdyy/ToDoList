using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using Domain.Tasks;
using static Application.Contracts.ToDoTasks.ChangePriority;
using MediatR;

namespace Application.RequestHandlers.ToDoTasks;

internal class ChangePriorityHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public ChangePriorityHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks.GetEntityByIdAsync(request.Id, cancellationToken);

        task.Priority = (TaskPriority)request.NewPriority;
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(task.AsDto());
    }
}