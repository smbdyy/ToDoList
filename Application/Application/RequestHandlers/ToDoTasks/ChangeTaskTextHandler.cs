using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using static Application.Contracts.ToDoTasks.ChangeTaskText;
using MediatR;

namespace Application.RequestHandlers.ToDoTasks;

internal class ChangeTaskTextHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public ChangeTaskTextHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks.GetEntityByIdAsync(request.Id, cancellationToken);

        task.Text = request.NewText;
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(task.AsDto());
    }
}