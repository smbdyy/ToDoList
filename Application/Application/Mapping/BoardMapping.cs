using Application.Dto;
using Domain.Tasks;

namespace Application.Mapping;

public static class BoardMapping
{
    public static BoardDto AsDto(this Board board)
        => new BoardDto(board.Id, board.Name.Value, board.Tasks.Select(task => task.AsDto()).ToArray());
}