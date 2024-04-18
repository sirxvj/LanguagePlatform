using Domain.DTOs;

namespace Application.Interfaces;

public interface IAccountService
{
    Task<TokenResponseDto?> Register(RegistrationDto user);
    Task<TokenResponseDto?> Login(LoginDto form);
}