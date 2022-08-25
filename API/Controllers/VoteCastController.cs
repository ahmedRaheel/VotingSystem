using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Application.VoteCast.Commands;
using VotingSystem.Application.VoteCast.Queries;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class VoteCastController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IVoteCastService _service;
    
    /// <summary>
    ///    Constructor
    /// </summary>
    /// <param name="mediator"></param>
    public VoteCastController(IMediator mediator, IVoteCastService service)
    {
        _mediator = mediator ?? throw new ArgumentNullException();
        _service = service  ?? throw new ArgumentNullException();
    }

    [HttpPost]
    public async Task<ActionResult<int>> VoteForCandidate(CastVoteCommand command)
    {
        return await _mediator.Send(command);
    } 

    [Route("[action]/{Id}")]
    [HttpGet]
    public async Task<IActionResult> GetVoteForCandidate([FromQuery]long Id)
    {
         var data = await _service.GetVotesByCanidate(Id);
         return Ok(data);  
    } 
}
