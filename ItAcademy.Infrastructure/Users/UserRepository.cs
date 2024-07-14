using ItAcademy.Application.Accounts.Constants;
using ItAcademy.Application.Accounts.Repositories;
using ItAcademy.Application.Infrastructure.Errors.CustomExceptions;
using ItAcademy.Application.Infrastructure.Localization.Errors;
using ItAcademy.Domain.UserAggregate;
using ItAcademy.Infrastructure.BaseRepo;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly IBaseRepository<User> _repository;
        public UserRepository(IBaseRepository<User> repository)
        {
            _repository = repository;
        }
        public async Task<User> GetById(CancellationToken token, int id)
        {
            return await _repository.GetQuery().SingleOrDefaultAsync(i => i.Id == id).ConfigureAwait(false);
        }
        public async Task<User> GetByUserName(CancellationToken token, string userName)
        {
            return await _repository.GetQuery().SingleOrDefaultAsync(i => i.UserName == userName).ConfigureAwait(false);
        }
        public async Task<IEnumerable<User>> GetUsers(CancellationToken token)
        {
            return await _repository.GetCollectionAsync(token, i => i.Status == true).ConfigureAwait(false);
        }

        public async Task<bool> AddUser(CancellationToken token, User user)
        {
            await _repository.Create(token, user).ConfigureAwait(false);
            return await _repository.SaveChangesAsync(token).ConfigureAwait(false);
        }
        public async Task<bool> MakeModerator(CancellationToken token, string userName)
        {
            var user = await _repository.GetQuery().SingleOrDefaultAsync(i => i.UserName == userName).ConfigureAwait(false);
            if (user == null)
                throw new DoesntExistsException(ErrorMessages.NotFound);
            user.Role = RoleType.Moderator.ToString();
            _repository.Update(user);
            return await _repository.SaveChangesAsync(token).ConfigureAwait(false);
        }
        public async Task<bool> DeleteUser(CancellationToken token, string userName)
        {
            var user = await _repository.GetQuery().SingleOrDefaultAsync(i => i.UserName == userName).ConfigureAwait(false);
            if (user == null)
                throw new DoesntExistsException(ErrorMessages.NotFound);
            user.Status = false;
            _repository.Update(user);
            return await _repository.SaveChangesAsync(token).ConfigureAwait(false);
        }

        
    }
}
