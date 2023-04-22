using Application.Dto;
using Domain.Tasks;

namespace Application.Mapping;

public static class ToDoTaskMapping
{
    public static ToDoTaskDto AsDto(this ToDoTask task)
        => new ToDoTaskDto(task.Id, task.Text.Value, (int)task.Priority, task.IsCompleted, task.Board.Id);
}