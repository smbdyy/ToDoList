using Application.Dto;
using MediatR;

namespace Application.Contracts.Boards;

public static class GetBoard
{
    public record struct Command(Guid Id) : IRequest<Response>;

    public record struct Response(BoardDto Board);
}