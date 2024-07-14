using ItAcademy.Domain.UserAggregate;

namespace ItAcademy.Application.Accounts.Repositories
{
    public interface IUserRepository
    {
        Task<bool> AddUser(CancellationToken token, User request);
        Task<IEnumerable<User>> GetUsers(CancellationToken token);
        Task<User> GetByUserName(CancellationToken token, string userName);
        Task<User> GetById(CancellationToken token, int id);
        Task<bool> MakeModerator(CancellationToken token, string userName);
        Task<bool> DeleteUser(CancellationToken token, string userName);
    }
}
