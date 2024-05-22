using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class TokenService : ITokenService
    {   
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config){
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:TokenKey"] ?? throw new InvalidOperationException()));
        }
        public string CreateToken(User user)
        {
            
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.NameId,user.Username),
                new(ClaimTypes.Role,user.Role.ToString())
            };

            var creds = new SigningCredentials(_key,SecurityAlgorithms.HmacSha256Signature);

            var descriptor = new SecurityTokenDescriptor{
                Expires = DateTime.Now.AddMinutes(1),
                SigningCredentials = creds,
                Subject = new ClaimsIdentity(claims) 
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}