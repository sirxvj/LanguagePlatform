using Application.Commands.Lessons;
using Application.Interfaces;
using Application.Queries.Lessons;
using Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LangPlatform.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class LessonsController:ControllerBase
{
    private readonly IMediator _mediator;

    public LessonsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}/reviews")]
    public async Task<ActionResult<IEnumerable<ReviewDto>>> GetLessonsReviews([FromRoute]Guid id)
    {
        return Ok(await _mediator.Send(new GetReviewsQuery(id)));
    }
    
    [HttpPost("{id}/reviews")]
    public async Task<ActionResult> PostComment([FromBody]CreateReviewDto review)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Validation error");
        }
        await _mediator.Send(new CreateReviewCommand(review));
        return Ok();
    }
}