using MediatR;

namespace Application.Contracts.Boards;

public static class DeleteBoard
{
    public record struct Command(Guid Id) : IRequest;
}