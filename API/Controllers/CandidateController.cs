using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Application.Candidate.Commands;
using VotingSystem.Application.Candidate.Queries;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CandidateController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICandidateService _service;
    
    /// <summary>
    ///    Constructor
    /// </summary>
    /// <param name="mediator"></param>
    public CandidateController(IMediator mediator, ICandidateService candidateService)
    {
        _mediator = mediator ?? throw new ArgumentNullException();
        _service = candidateService ?? throw new ArgumentNullException();
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateCandidate(CreateCandidateCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut]
    public async Task<ActionResult<int>> AddCandidateToCategory(AddCandidateToCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet(Name = "GetCandidates")]
    public async Task<IActionResult> GetCandidates()
    {
         var data = await _service.GetCandidates();
         return Ok(data);  
    }

    [Route("[action]/{Id}")]
    [HttpGet]
    public async Task<IActionResult> GetCandidateById([FromQuery]long Id)
    {
         var data = await _service.GetCandidateById(Id);
         return Ok(data);  
    }
}
