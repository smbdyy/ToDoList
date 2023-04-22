using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using MediatR;
using static Application.Contracts.Boards.GetBoard;

namespace Application.RequestHandlers.Boards;

internal class GetBoardHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public GetBoardHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var board = await _context.Boards.GetEntityByIdAsync(request.Id, cancellationToken);
        return new Response(board.AsDto());
    }
}