using Application.Interfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LangPlatform.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AccountController:ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<TokenResponseDto>> Login([FromBody]LoginDto form)
    {
        var token = await _accountService.Login(form);
        if (token is null) return Unauthorized("Wrong login or password");
        return Ok(token);
    }

    [HttpPost("register")]
    public async Task<ActionResult<TokenResponseDto>> Register([FromBody] RegistrationDto form)
    {
        var token = await _accountService.Register(form);
        if (token is null) return Unauthorized($"User with {form.Username} username exists");
        return Ok(token);
    }
}