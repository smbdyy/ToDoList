using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using static Application.Contracts.ToDoTasks.ChangeBoard;
using MediatR;

namespace Application.RequestHandlers.ToDoTasks;

internal class ChangeBoardHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public ChangeBoardHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var task = await _context.Tasks.GetEntityByIdAsync(request.TaskId, cancellationToken);
        var newBoard = await _context.Boards.GetEntityByIdAsync(request.NewBoardId, cancellationToken);

        task.MoveToBoard(newBoard);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(task.AsDto());
    }
}