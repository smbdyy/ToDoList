using Application.Contracts.ToDoTasks;
using Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoTaskController : ControllerBase
{
    private readonly IMediator _mediator;

    public ToDoTaskController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("create")]
    public async Task<ActionResult<ToDoTaskDto>> CreateAsync([FromForm] CreateToDoTaskModel model)
    {
        var command = new CreateToDoTask.Command(model.Name, model.Priority, model.BoardId);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.ToDoTask);
    }

    [HttpPost("changeBoard")]
    public async Task<ActionResult<ToDoTaskDto>> ChangeBoardAsync([FromQuery] Guid taskId, [FromForm] Guid newBoardId)
    {
        var command = new ChangeBoard.Command(taskId, newBoardId);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.ToDoTask);
    }

    [HttpPost("changePriority")]
    public async Task<ActionResult<ToDoTaskDto>> ChangePriorityAsync(
        [FromQuery] Guid taskId,
        [FromForm] int newPriority)
    {
        var command = new ChangePriority.Command(taskId, newPriority);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.ToDoTask);
    }

    [HttpPost("changeTaskText")]
    public async Task<ActionResult<ToDoTaskDto>> ChangeTaskTextAsync(
        [FromQuery] Guid taskId,
        [FromForm] string newText)
    {
        var command = new ChangeTaskText.Command(taskId, newText);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.ToDoTask);
    }

    [HttpGet("delete")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var command = new DeleteToDoTask.Command(id);
        await _mediator.Send(command, CancellationToken);

        return Ok();
    }

    [HttpGet("toggle")]
    public async Task<ActionResult<ToDoTaskDto>> ToggleAsync(Guid id)
    {
        var command = new ToggleIsCompleted.Command(id);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.ToDoTask);
    }
}