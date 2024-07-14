using FluentValidation;
using ItAcademy.Domain.EventsAggregate;

namespace ItAcademy.API.Infrastructure.Validations
{
    public class EventValidation : AbstractValidator<Event>
    {
        public EventValidation()
        {
            RuleFor(i => i.Title).Length(1, 50).WithMessage("Title must be short!");
            RuleFor(i => i.Description).Length(10, 500).WithMessage("Description must be between 10 and 500!");
            RuleFor(i => i.Price).GreaterThanOrEqualTo(1).WithMessage("Price must be more than 1 lari");
            RuleFor(i => i.Quantity).GreaterThanOrEqualTo(1).WithMessage("Quantity must be more than 1");
            RuleFor(i => i.Location).Length(5, 100).WithMessage("Length must be between 5 and 100");
        }
    }
}
