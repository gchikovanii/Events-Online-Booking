using ItAcademy.Application.Accounts.Constants;
using ItAcademy.Application.Accounts.Helper;
using ItAcademy.Application.Accounts.Repositories;
using ItAcademy.Application.Accounts.Requests;
using ItAcademy.Application.Accounts.Responses;
using ItAcademy.Application.Infrastructure.Errors.CustomExceptions;
using ItAcademy.Application.Infrastructure.Localization.Errors;
using ItAcademy.Domain.UserAggregate;
using Mapster;

namespace ItAcademy.Application.Accounts
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> ShowActiveUsers(CancellationToken token)
        {
            return await _userRepository.GetUsers(token).ConfigureAwait(false);
        }
        public async Task<bool> RegisterUser(CancellationToken token, RegisterUserRequest request)
        {
            var user = request.Adapt<User>();
            var userExists = await _userRepository.GetByUserName(token, request.UserName).ConfigureAwait(false);
            if (userExists != null)
                throw new AlreadyExistsException(ErrorMessages.AlreadyExists);
            user.PasswordHash = PasswordHashGenerator.HashPassword(user.PasswordHash);
            user.Email = request.Email;
            user.CreatedAt = DateTimeOffset.Now;
            user.Role = RoleType.User.ToString();
            return await _userRepository.AddUser(token, user).ConfigureAwait(false);
        }

        public async Task<UserRepsonse> SignIn(CancellationToken token, LogInUserRequest request)
        {
            var userExists = await _userRepository.GetByUserName(token, request.UserName).ConfigureAwait(false);
            if (userExists == null)
                throw new DoesntExistsException(ErrorMessages.NotFound);
            var passwordHash = PasswordHashGenerator.HashPassword(request.PasswordHash);
            if (userExists.UserName == request.UserName && userExists.PasswordHash == passwordHash)
                return userExists.Adapt<UserRepsonse>();
            else
                throw new IncorrectInfoException(ErrorMessages.IncorrectInfo);
        }
        public async Task<bool> MakeModerator(CancellationToken token, string userName)
        {
            var userExists = await _userRepository.GetByUserName(token, userName).ConfigureAwait(false);
            if (userExists == null)
                throw new DoesntExistsException(ErrorMessages.NotFound);
            return await _userRepository.DeleteUser(token, userName).ConfigureAwait(false);
        }
        public async Task<bool> DeactivateAccount(CancellationToken token, string userName)
        {
            var userExists = await _userRepository.GetByUserName(token, userName).ConfigureAwait(false);
            if (userExists == null)
                throw new DoesntExistsException(ErrorMessages.NotFound);
            return await _userRepository.DeleteUser(token, userName).ConfigureAwait(false);
        }
    }
}
