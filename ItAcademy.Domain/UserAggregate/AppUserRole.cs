using Microsoft.AspNetCore.Identity;

namespace ItAcademy.Domain.UserAggregate
{
    public class AppUserRole : IdentityUserRole<string>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}
