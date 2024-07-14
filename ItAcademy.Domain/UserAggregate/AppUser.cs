using System.ComponentModel.DataAnnotations;
using ItAcademy.Domain.EventsAggregate;
using ItAcademy.Domain.OrderAggregate;
using Microsoft.AspNetCore.Identity;

namespace ItAcademy.Domain.UserAggregate
{
    public class AppUser : IdentityUser<string>
    {
        //[Display(Name = "UserName")]
        //public string UserName { get; set; }
        //[Display(Name = "Email")]
        //public string Email { get; set; }
        //[Display(Name = "Roles")]
        //public string Role { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        //public string PasswordHash { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Order> Orders { get; set; }
        public bool Status { get; set; } = true;
        public DateTimeOffset CreatedAt { get; set; }
        public ICollection<AppUserRole> AppUserRoles { get; set; }
    }
}
