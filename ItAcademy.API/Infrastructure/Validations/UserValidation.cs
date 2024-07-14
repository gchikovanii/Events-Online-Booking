using FluentValidation;
using FluentValidation.Validators;
using ItAcademy.Domain.UserAggregate;

namespace ItAcademy.API.Infrastructure.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(i => i.UserName).NotEmpty().Length(1, 50)
                .WithMessage("User Name must be between 1 and 50");
            RuleFor(i => i.Email).NotEmpty().Length(1, 50)
                .WithMessage("Email must be between 1 and 50")
                .EmailAddress().WithMessage("Right Email format is required!");
            RuleFor(i => i.PasswordHash).NotEmpty().Length(5, 100).WithMessage("Password Length Must be more than 5");
        }
    }
}
