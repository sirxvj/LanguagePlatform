using System.Security.Cryptography;
using System.Text;
using Application.Interfaces;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

public class AccountService:IAccountService
{
    private readonly IRepository<User> _userRepository;
    private readonly ITokenService _tokenService;

    public AccountService( ITokenService tokenService, IRepository<User> userRepository)
    {
        _tokenService = tokenService;
        _userRepository = userRepository;
    }

    public async Task<TokenResponseDto?> Register(RegistrationDto user)
    {
        if (((await _userRepository.GetAllAsync(x=>x.Username==user.Username))?? Enumerable.Empty<User>()).Count() !=0) return null;
            
        using var hmac = new HMACSHA256();

        var newUser = new User()
        {
            Id = Guid.NewGuid(),
            Username = user.Username,
            Email = user.Email,
            Role = RoleType.Readonly,
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password)),
            PasswordSalt = hmac.Key
        };
        await _userRepository.CreateAsync(newUser);
        return new TokenResponseDto(newUser.Id, user.Username,_tokenService.CreateToken(newUser));
    }

    public async Task<TokenResponseDto?> Login(LoginDto form)
    {
        var user = await _userRepository.GetAsync(u=>u.Username==form.Username);

        if(user == null) return null;

        using var hmac = new HMACSHA256(user.PasswordSalt);

        var loginHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(form.Password));

        if(!Enumerable.SequenceEqual(loginHash,user.PasswordHash)){
            return null;
        }
        return new TokenResponseDto(user.Id,user.Username,_tokenService.CreateToken(user));
    }
}