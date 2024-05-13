using Application.Interfaces;
using Application.Queries.Categories;
using Application.Queries.Languages;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LangPlatform.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CategoriesController:ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    } 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetDifficulty()
    {
        return Ok(await _mediator.Send(new GetAllCategoriesQuery()));
    }
    
    [HttpGet("lang")]
    public async Task<ActionResult<IEnumerable<Language>>> GetLanguage()
    {
        return Ok(await _mediator.Send(new GetAllLanguagesQuery()));
    }
}