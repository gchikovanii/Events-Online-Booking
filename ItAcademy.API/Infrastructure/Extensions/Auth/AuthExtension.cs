using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ItAcademy.API.Infrastructure.Extensions.Auth
{
    public static class AuthExtension
    {
        public static IServiceCollection AddTokenAuth(this IServiceCollection services, string key)
        {
            var keyInBytes = Encoding.ASCII.GetBytes(key);
            services.AddAuthentication(i =>
            {
                i.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                i.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(i => i.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(keyInBytes),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = "localhost",
                ValidAudience = "localhost"
            });
            return services;
        }
    }
}
