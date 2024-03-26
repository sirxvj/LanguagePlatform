using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LangPlatform.Controllers;

[ApiController]
public class HomeController:ControllerBase
{
    // private readonly IExperimentalRepo _repo;
    //
    // public HomeController(IExperimentalRepo repo)
    // {
    //     _repo = repo;
    // }
    //
    // [HttpGet("{name}")]
    // public async Task<ActionResult<IEnumerable<Language>>> Index([FromRoute]string name)
    // {
    //     // await _repo.Create(new Language
    //     // {
    //     //     Id = Guid.NewGuid(),
    //     //     Name = name
    //     // });
    //     return Ok(await _repo.GetAll());
    // }
}