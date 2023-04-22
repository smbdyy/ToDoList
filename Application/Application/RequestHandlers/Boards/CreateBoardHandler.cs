using Application.Abstractions.DataAccess;
using Application.Mapping;
using Domain.Tasks;
using MediatR;
using static Application.Contracts.Boards.CreateBoard;

namespace Application.RequestHandlers.Boards;

internal class CreateBoardHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public CreateBoardHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var board = new Board(Guid.NewGuid(), request.Name);

        _context.Boards.Add(board);
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(board.AsDto());
    }
}