using System.Security.Cryptography;
using System.Text;
using Application.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.Users;

public record RegisterUserCommand(
    RegistrationDto Form
    ):IRequest<TokenResponseDto?>;


public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, TokenResponseDto?>
{
    private readonly DataContext _dataContext;
    private readonly ITokenService _tokenService;
    public RegisterUserHandler(DataContext dataContext, ITokenService tokenService)
    {
        _dataContext = dataContext;
        _tokenService = tokenService;
    }

    public async Task<TokenResponseDto?> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (await _dataContext
                .Users
                .Where(x => x.Username == request.Form.Username)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken) is not null)
        {
            return null;
        }
        using var hmac = new HMACSHA256();

        var newUser = new User()
        {
            Id = Guid.NewGuid(),
            Username = request.Form.Username,
            Email = request.Form.Email,
            Role = RoleType.Readonly,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Form.Password)),
            PasswordSalt = hmac.Key
        };
        await _dataContext.Users.AddAsync(newUser);
        await _dataContext.SaveChangesAsync(cancellationToken);
        return new TokenResponseDto(newUser.Id, request.Form.Username,_tokenService.CreateToken(newUser));
    }
}