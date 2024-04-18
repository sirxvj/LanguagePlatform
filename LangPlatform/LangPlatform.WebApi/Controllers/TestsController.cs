using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LangPlatform.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestsController:ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<CreateAnswerDto>> Index([FromBody]CreateAnswerDto user)
    {
        throw new NotImplementedException();
        return BadRequest(user);
    }
}