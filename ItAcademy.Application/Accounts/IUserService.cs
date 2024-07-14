using ItAcademy.Application.Accounts.Requests;
using ItAcademy.Application.Accounts.Responses;
using ItAcademy.Domain.UserAggregate;

namespace ItAcademy.Application.Accounts
{
    public interface IUserService
    {
        Task<bool> RegisterUser(CancellationToken token, RegisterUserRequest request);
        Task<UserRepsonse> SignIn(CancellationToken token, LogInUserRequest request);
        Task<bool> DeactivateAccount(CancellationToken token, string userName);
        Task<bool> MakeModerator(CancellationToken token, string userName);
        Task<IEnumerable<User>> ShowActiveUsers(CancellationToken token); 
    }
}
