using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Application.Voter.Commands;
using VotingSystem.Application.Voter.Queries;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class VoterController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IVoterService _service;
    /// <summary>
    ///    Constructor
    /// </summary>
    /// <param name="mediator"></param>
    public VoterController(IMediator mediator, IVoterService service)
    {
        _mediator = mediator ?? throw new ArgumentNullException();
        _service = service ?? throw new ArgumentNullException();
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateVoter(CreateVoterCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    public async Task<ActionResult<int>> UpdateVoterAge(UpdateVoterAgeCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpDelete]
    public async Task<ActionResult<int>> DeleteVoter(DeleteVoterCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet(Name = "GetVoters")]
    public async Task<IActionResult> GetVoters()
    {
         var data = await _service.GetVoters();
         return Ok(data);  
    }
}
