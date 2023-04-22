using Application.Dto;
using MediatR;

namespace Application.Contracts.Boards;

public static class CreateBoard
{
    public record struct Command(string Name) : IRequest<Response>;

    public record struct Response(BoardDto Board);
}