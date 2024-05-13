using Application.Commands.Users;
using Application.Interfaces;
using Application.Queries.Users;
using Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LangPlatform.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AccountController:ControllerBase
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<TokenResponseDto>> Login([FromBody]LoginDto form)
    {
        var token = await _mediator.Send(new LoginUserQuery(form));
        if (token is null) return Unauthorized("Wrong login or password");
        return Ok(token);
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<TokenResponseDto>> Register([FromBody] RegistrationDto form)
    {
        var token = await _mediator.Send(new RegisterUserCommand(form));
        if (token is null) return Unauthorized($"User with {form.Username} username exists");
        return Ok(token);
    }
}