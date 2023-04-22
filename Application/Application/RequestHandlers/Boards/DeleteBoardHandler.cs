using Application.Abstractions.DataAccess;
using Application.Extensions;
using MediatR;
using static Application.Contracts.Boards.DeleteBoard;

namespace Application.RequestHandlers.Boards;

internal class DeleteBoardHandler : IRequestHandler<Command>
{
    private readonly IDatabaseContext _context;

    public DeleteBoardHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
    {
        var board = await _context.Boards.GetEntityByIdAsync(request.Id, cancellationToken);

        _context.Boards.Remove(board);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}