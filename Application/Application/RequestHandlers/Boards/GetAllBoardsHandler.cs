using Application.Abstractions.DataAccess;
using Application.Mapping;
using MediatR;
using static Application.Contracts.Boards.GetAllBoards;

namespace Application.RequestHandlers.Boards;

internal class GetAllBoardsHandler : IRequestHandler<Command, Response>
{
    private readonly IDatabaseContext _context;

    public GetAllBoardsHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public Task<Response> Handle(Command request, CancellationToken cancellationToken)
    {
        return Task.FromResult(new Response(_context.Boards.Select(x => x.AsDto()).ToArray()));
    }
}