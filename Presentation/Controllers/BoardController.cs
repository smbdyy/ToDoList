using Application.Contracts.Boards;
using Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoardController : ControllerBase
{
    private readonly IMediator _mediator;

    public BoardController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost("create")]
    public async Task<ActionResult<BoardDto>> CreateAsync([FromForm] string name)
    {
        var command = new CreateBoard.Command(name);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.Board);
    }

    [HttpPost("changeName")]
    public async Task<ActionResult<BoardDto>> ChangeNameAsync([FromQuery] Guid id, [FromForm] string name)
    {
        var command = new ChangeName.Command(id, name);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.Board);
    }

    [HttpGet("delete")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        var command = new DeleteBoard.Command(id);
        await _mediator.Send(command, CancellationToken);

        return Ok();
    }

    [HttpGet("get")]
    public async Task<ActionResult<BoardDto>> GetAsync(Guid id)
    {
        var command = new GetBoard.Command(id);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.Board);
    }

    [HttpGet("all")]
    public ActionResult<IReadOnlyCollection<BoardDto>> GetAll()
    {
        var command = new GetAllBoards.Command();
        var response = _mediator.Send(command, CancellationToken);

        return Ok(response.Result.Boards);
    }
}