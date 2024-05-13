using Application.Commands.Tests;
using Application.Interfaces;
using Application.Queries.Lessons;
using Application.Queries.Test;
using Domain.DTOs;
using Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LangPlatform.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class TestsController:ControllerBase
{
    private readonly IMediator _mediator;

    public TestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LessonDto>>> GetAllRaw()
    {
        return Ok(await _mediator.Send(
            new GetLessonsFilteredQuery(Approved:true,Type:LessonType.Test)));
    }

    [HttpPost]
    public async Task<ActionResult> CreateTest([FromBody]CreateTestDto test)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _mediator.Send(new CreateTestCommand(test));
        return Ok();
    }

    [HttpGet("answers/{id}/accuracy")]
    public async Task<ActionResult<bool>> CheckAccuracy([FromRoute]Guid id)
    {
        return await _mediator.Send(new GetAnswerAccuracyQuery(id));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TestObjectDto>> GetDetailed([FromRoute]Guid id)
    {
        return Ok(await _mediator.Send(new GetTestQuery(id)));
    }
}