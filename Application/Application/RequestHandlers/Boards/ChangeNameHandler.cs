using Application.Abstractions.DataAccess;
using Application.Extensions;
using Application.Mapping;
using MediatR;
using static Application.Contracts.Boards.ChangeName;

namespace Application.RequestHandlers.Boards;

internal class ChangeNameHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public ChangeNameHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        var board = await _context.Boards.GetEntityByIdAsync(request.Id, cancellationToken);

        board.Name = request.NewName;
        await _context.SaveChangesAsync(cancellationToken);

        return new Response(board.AsDto());
    }
}