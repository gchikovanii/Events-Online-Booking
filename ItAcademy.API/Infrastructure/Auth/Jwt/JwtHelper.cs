using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ItAcademy.API.Infrastructure.Auth.Jwt
{
    public class JwtHelper
    {
        public static string GenerateToken(string userName, string role, IOptions<JwtConfiguration> options)
        {
            var key = Encoding.ASCII.GetBytes(options.Value.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("UserName",$"{userName}"),
                    new Claim("Role",$"{role}")
                }),
                Expires = DateTime.UtcNow.AddMinutes(options.Value.ExpDate),
                Audience = "localhost",
                Issuer = "localhost",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
