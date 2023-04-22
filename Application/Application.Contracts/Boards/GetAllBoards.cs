using Application.Dto;
using MediatR;

namespace Application.Contracts.Boards;

public static class GetAllBoards
{
    public record struct Command : IRequest<Response>;

    public record struct Response(IReadOnlyCollection<BoardDto> Boards);
}