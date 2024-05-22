using Application.Commands.Users;
using Application.Queries.Users;
using Domain.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LangPlatform.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class CommunityController:ControllerBase
{
    private readonly IMediator _mediator;

    public CommunityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("userform/{id}")]
    public async Task<ActionResult<UserFormDto>> GetUserFormById([FromRoute] Guid id)
    {
        return Ok(await _mediator.Send(new GetUserFormQuery(id)));
    }

    [HttpGet("userform")]
    public async Task<ActionResult<IEnumerable<UserFormUserDto>>> GetUserFormFiltered([FromQuery] Guid? langId = null,
        [FromQuery] Guid? catId=null)
    {
        return Ok(await _mediator.Send(new GetUserFormsFilteredQuery(catId,langId)));
    }

    [HttpGet("{id}/friends")]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersFriends([FromRoute] Guid userId)
    {
        return Ok(await _mediator.Send(new GetUsersFriendsQuery(userId)));
    }
 
    [HttpPut("userform")]
    public async Task<ActionResult> UpdateUserForm([FromBody]UserFormDto userForm)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await _mediator.Send(new UpdateUserFormCommand(userForm));
        return Ok();
    }

    [HttpPost("friends")]
    public async Task<ActionResult> MakeFriends([FromBody] FriendDto friends)
    {
        await _mediator.Send(new MakeFriendCommand(friends.UserId, friends.User2Id));
        return Ok();
    }
    
    
 }