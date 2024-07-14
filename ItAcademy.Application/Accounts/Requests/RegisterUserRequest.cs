using ItAcademy.Application.Accounts.Constants;

namespace ItAcademy.Application.Accounts.Requests
{
    public class RegisterUserRequest
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Gender Gender { get; set; }
    }
}
