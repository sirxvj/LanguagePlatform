using Domain.DTOs;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAccountService
{
    Task<TokenResponseDto> Register(RegistrationDto user);
    Task<TokenResponseDto> Login(LoginDto form);
}