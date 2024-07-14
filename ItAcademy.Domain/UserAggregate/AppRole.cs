using Microsoft.AspNetCore.Identity;

namespace ItAcademy.Domain.UserAggregate
{
    public class AppRole : IdentityRole<string>
    {
        public ICollection<AppUserRole> AppUserRoles { get; set; }
    }
}
