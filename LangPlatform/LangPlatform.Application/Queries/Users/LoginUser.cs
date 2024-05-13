using System.Security.Cryptography;
using System.Text;
using Application.Interfaces;
using Domain.DTOs;
using Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Users;

public record LoginUserQuery(
    LoginDto Form
    ):IRequest<TokenResponseDto?>;

public class LoginUserHandler : IRequestHandler<LoginUserQuery,TokenResponseDto?>
{
    private readonly DataContext _dataContext;
    private readonly ITokenService _tokenService;
    public LoginUserHandler(DataContext dataContext, ITokenService tokenService)
    {
        _dataContext = dataContext;
        _tokenService = tokenService;
    }

    public async Task<TokenResponseDto?> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _dataContext.Users.Where(u=>u.Username==request.Form.Username).FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if(user == null) return null;

        using var hmac = new HMACSHA256(user.PasswordSalt);

        var loginHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Form.Password));

        if(!Enumerable.SequenceEqual(loginHash,user.PasswordHash)){
            return null;
        }
        return new TokenResponseDto(user.Id,user.Username,_tokenService.CreateToken(user));
    }
}