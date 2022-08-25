using MediatR;
using Microsoft.AspNetCore.Mvc;
using VotingSystem.Application.CandidateCategory.Commands;
using VotingSystem.Application.CandidateCategory.Queries;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CandidateCategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ICandidateCategoryService _service;
    
    /// <summary>
    ///   
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="service"></param>
    public CandidateCategoryController(IMediator mediator,ICandidateCategoryService service)
    {
        _mediator = mediator;
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCategoryCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet(Name = "GetCategories")]
    public async Task<IActionResult> GetCategories()
    {
         var data = await _service.GetCandidateCategory();
         return Ok(data);  
    }
     
    [Route("[action]/{Id}")]
    [HttpGet]
    public async Task<IActionResult> GetCategoryById([FromQuery]long Id)
    {
         var data = await _service.GetCandidateCategoryById(Id);
         return Ok(data);  
    }
}
