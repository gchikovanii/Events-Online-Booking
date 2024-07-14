using ItAcademy.Application.Accounts.Constants;
using ItAcademy.Domain.UserAggregate;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ItAcademy.Persistence.DatSeed
{
    public class UserSeed
    {
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                if (!await roleManager.RoleExistsAsync(RoleType.Admin.ToString()).ConfigureAwait(false))
                    await roleManager.CreateAsync(new IdentityRole(RoleType.Admin.ToString())).ConfigureAwait(false);
                if (!await roleManager.RoleExistsAsync(RoleType.User.ToString()).ConfigureAwait(false))
                    await roleManager.CreateAsync(new IdentityRole(RoleType.User.ToString())).ConfigureAwait(false);
                if (!await roleManager.RoleExistsAsync(RoleType.Moderator.ToString()).ConfigureAwait(false))
                    await roleManager.CreateAsync(new IdentityRole(RoleType.Moderator.ToString())).ConfigureAwait(false);

                //Seed Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                var adminUserEmail = "admin@ItAcademy.ge";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail).ConfigureAwait(false);
                if (adminUser == null)
                {
                    var newAdminUser = new AppUser
                    {
                        UserName = "admin",
                        Status = true,
                        CreatedAt = DateTimeOffset.Now,
                        Email = "admin@gmail.com",
                        Gender = Gender.male.ToString(),
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin_1!").ConfigureAwait(false);
                    await userManager.AddToRoleAsync(newAdminUser, RoleType.Admin.ToString()).ConfigureAwait(false);
                }

                var userEmail = "gio@gmail.com";
                var userExists = await userManager.FindByEmailAsync(userEmail).ConfigureAwait(false);
                if (userExists == null)
                {
                    var newUser = new AppUser
                    {
                        UserName = "gio",
                        Status = true,
                        CreatedAt = DateTimeOffset.Now,
                        Email = "admin@gmail.com",
                        Gender = Gender.male.ToString(),
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newUser, "Gio_1!").ConfigureAwait(false);
                    await userManager.AddToRoleAsync(newUser, RoleType.User.ToString()).ConfigureAwait(false);
                }
                var secondUserEmail = "gio@gmail.com";
                var secondUserExists = await userManager.FindByEmailAsync(secondUserEmail).ConfigureAwait(false);
                if (secondUserExists == null)
                {
                    var newUser = new AppUser
                    {
                        UserName = "nona",
                        Status = true,
                        CreatedAt = DateTimeOffset.Now,
                        Email = "nona@gmail.com",
                        Gender = Gender.female.ToString(),
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newUser, "Gio_1!").ConfigureAwait(false);
                    await userManager.AddToRoleAsync(newUser, RoleType.User.ToString()).ConfigureAwait(false);
                }
            }
        }
    }
}
