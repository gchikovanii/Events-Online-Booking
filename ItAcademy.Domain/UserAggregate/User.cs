using System.ComponentModel.DataAnnotations;
using ItAcademy.Domain.BaseEntity;
using ItAcademy.Domain.EventsAggregate;
using ItAcademy.Domain.OrderAggregate;

namespace ItAcademy.Domain.UserAggregate
{
    public class User : Entity
    {
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Roles")]
        public string Role { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
