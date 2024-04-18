using Application.Interfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LangPlatform.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class LessonsController:ControllerBase
{
    private readonly ILessonService _lessonService;

    public LessonsController(ILessonService lessonService)
    {
        _lessonService = lessonService;
    }

    [HttpGet("{id}/reviews")]
    public async Task<ActionResult<IEnumerable<ReviewDto>>> GetLessonsReviews([FromRoute]Guid id)
    {
        return Ok(await _lessonService.GetReviewsFull(id));
    }

    [HttpPost("{id}/reviews")]
    public async Task<ActionResult> PostComment([FromBody]CreateReviewDto review)
    {
        await _lessonService.AddReview(review);
        return Ok();
    }
}