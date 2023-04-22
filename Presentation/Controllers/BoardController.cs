using Application.Contracts.Boards;
using Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models.Boards;

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

    [HttpPost]
    public async Task<ActionResult<BoardDto>> CreateAsync([FromBody] CreateBoardModel model)
    {
        var command = new CreateBoard.Command(model.Name);
        var response = await _mediator.Send(command, CancellationToken);

        return Ok(response.Board);
    }
}