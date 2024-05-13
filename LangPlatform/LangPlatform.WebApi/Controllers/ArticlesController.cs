using Application.Commands.Articles;
using Application.Interfaces;
using Application.Queries.Articles;
using Application.Queries.Lessons;
using Domain.DTOs;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LangPlatform.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ArticlesController:ControllerBase
{
    private readonly IMediator _mediator;

    public ArticlesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]           ////   IMPLEMENT PAGINATION
    public async Task<ActionResult<IEnumerable<LessonDto>>> GetAllRaw()
    {
        return Ok(await _mediator.Send(
            new GetLessonsFilteredQuery(Approved:true,Type:LessonType.Article)));
    }
    [HttpGet("unaprooved")]
    public async Task<ActionResult<IEnumerable<LessonDto>>> GetUnapproved()
    {
        return Ok(await _mediator.Send(
            new GetLessonsFilteredQuery(Approved:false,Type:LessonType.Article)));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ArticleDto>> GetDetailed([FromRoute]Guid id)
    {
        return Ok(await _mediator.Send(new DownloadArticleQuery(id)));
    }
    //
    [HttpPost]
    public async Task<ActionResult> PostArticle([FromBody] CreateArticleDto article)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _mediator.Send(new UploadArticleCommand(article));
        return Ok();
    }
}