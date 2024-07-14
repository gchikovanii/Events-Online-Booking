using ItAcademy.API.Infrastructure.Auth.Jwt;
using ItAcademy.Application.Accounts;
using ItAcademy.Application.Accounts.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ItAcademy.API.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IOptions<JwtConfiguration> _options;
        public AccountController(IUserService userService, IOptions<JwtConfiguration> options)
        {
            _userService = userService;
            _options = options;
        }
        [HttpPost("register")]
        public async Task<ActionResult<bool>> Register(CancellationToken token, RegisterUserRequest request)
        {
            return await _userService.RegisterUser(token, request).ConfigureAwait(false);
        }
        [HttpPost("access-token")]
        public async Task<string> LogIn(CancellationToken token, LogInUserRequest request)
        {
            var result = await _userService.SignIn(token, request).ConfigureAwait(false);
            return JwtHelper.GenerateToken(result.UserName, result.Role, _options);
        }
    }
}
