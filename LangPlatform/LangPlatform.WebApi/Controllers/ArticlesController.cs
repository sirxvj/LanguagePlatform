using Application.Interfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LangPlatform.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ArticlesController:ControllerBase
{
    private readonly IArticleService _articleService;
    private readonly ILessonService _lessonService;
    
    public ArticlesController(IArticleService articleService, ILessonService lessonService)
    {
        _articleService = articleService;
        _lessonService = lessonService;
    }

    [HttpGet]           ////   IMPLEMENT PAGINATION
    public async Task<ActionResult<IEnumerable<LessonDto>>> GetAllRaw()
    {
        return Ok(await _lessonService.GetFiltered(approved:true,type: "article"));
    }
    
    
    [HttpGet("unaprooved")]
    public async Task<ActionResult<IEnumerable<LessonDto>>> GetUnapproved()
    {
        return Ok(await _lessonService.GetFiltered(approved: false, type: "article"));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ArticleDto>> GetDetailed([FromRoute]Guid id)
    {
        return Ok(await _articleService.DownloadArticle(id));
    }

    [HttpPost]
    public async Task<ActionResult> PostArticle([FromBody] CreateArticleDto article)
    {
        if (!ModelState.IsValid)
        {
            // LogErrors(ModelState);
            return BadRequest(ModelState);
        }
        await _articleService.UploadArticle(article);
        return Ok();
    }
}