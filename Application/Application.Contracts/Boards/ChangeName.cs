using Application.Dto;
using MediatR;

namespace Application.Contracts.Boards;

public static class ChangeName
{
    public record struct Command(Guid Id, string NewName) : IRequest<Response>;

    public record struct Response(BoardDto Board);
}