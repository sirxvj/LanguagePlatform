using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LangPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController:ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly ILanguageService _languageService;

    public CategoriesController(ICategoryService categoryService, ILanguageService languageService)
    {
        _categoryService = categoryService;
        _languageService = languageService;
    }

    [HttpGet]
    public async Task<ActionResult<Category>> GetDifficulty()
    {
        return Ok((await _categoryService.GetAll() ?? Array.Empty<Category?>()).Select(c=>c.Name));
    }

    [HttpGet("lang")]
    public async Task<ActionResult<Language>> GetLanguage()
    {
        return Ok((await _languageService.GetAll() ?? throw new InvalidOperationException()).Select(x=>x.Name));
    }
}