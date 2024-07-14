using ItAcademy.Application.Accounts.Constants;
using ItAcademy.Application.Accounts.Helper;
using ItAcademy.Domain.EventsAggregate;
using ItAcademy.Domain.UserAggregate;
using ItAcademy.Persistence.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ItAcademy.Persistence.DatSeed
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var database = scope.ServiceProvider.GetRequiredService<ItAcademyDbContext>();
            Migrate(database);
            SeedAll(database);
        }
        private static void Migrate(ItAcademyDbContext context)
        {
            context.Database.Migrate();
        }

        private static void SeedAll(ItAcademyDbContext context)
        {
            var seeded = false;
            SeedUsers(context, ref seeded);
            SeedEvents(context, ref seeded);
            if (seeded)
                context.SaveChanges();
        }
        private static void SeedUsers(ItAcademyDbContext context, ref bool seeded)
        {
            var users = new List<User>()
            {
                new User
                {
                    UserName = "admin",
                    PasswordHash = PasswordHashGenerator.HashPassword("admin"),
                    Status = true,
                    CreatedAt = DateTimeOffset.Now,
                    Email = "admin@gmail.com",
                    Role = RoleType.Admin.ToString(),
                    Gender = Gender.male.ToString()
                },
                new User
                {
                    UserName = "gio",
                    PasswordHash = PasswordHashGenerator.HashPassword("gio"),
                    Status = true,
                    CreatedAt = DateTimeOffset.Now,
                    Email = "gio@gmail.com",
                    Role = RoleType.User.ToString(),
                    Gender = Gender.male.ToString()
                },
                new User
                {
                    UserName = "eka",
                    PasswordHash = PasswordHashGenerator.HashPassword("eka"),
                    Status = true,
                    CreatedAt = DateTimeOffset.Now,
                    Email = "eka@gmail.com",
                    Role = RoleType.User.ToString(),
                    Gender = Gender.female.ToString()
                },
                new User
                {
                    UserName = "nona",
                    PasswordHash = PasswordHashGenerator.HashPassword("gio"),
                    Status = true,
                    CreatedAt = DateTimeOffset.Now,
                    Email = "nona@gmail.com",
                    Role = RoleType.User.ToString(),
                    Gender = Gender.female.ToString()
                }
            };
            foreach (var user in users)
            {
                if (context.Users.Any(x => x.UserName == user.UserName))
                    continue;
                context.Users.Add(user);
                seeded = true;
            }
        }
        private static void SeedEvents(ItAcademyDbContext context, ref bool seeded)
        {
            var events = new List<Event>()
            {
                new Event
                {
                    Title = "Georgia v Norway",
                    Description = "Football Match between georgia and norway",
                    StartDate = DateTimeOffset.UtcNow.AddDays(5),
                    EndDate = DateTimeOffset.UtcNow.AddDays(5).AddHours(2),
                    Status = true,
                    Approved = true,
                    CreatedAt = DateTimeOffset.UtcNow,
                    Location = "Batumi Areana",
                    Price = 35,
                    Quantity = 25_000,
                    UserId = 5,
                    Image = "https://scontent.ftbs10-1.fna.fbcdn.net/v/t39.30808-6/333973964_1111153586946242_4059699145482184093_n.jpg?_nc_cat=110&ccb=1-7&_nc_sid=8bfeb9&_nc_eui2=AeGeVUbT-RPq4m-sdAQnYTl9gdhPsjy2OluB2E-yPLY6W9w5R2NJbiKe5eKs4uYgMAdp2hrtA9ct0d_xTcO9Ndx0&_nc_ohc=K3JytFeFTioAX9keTl8&_nc_ht=scontent.ftbs10-1.fna&oh=00_AfAuFd1vJ13s4zj9uIO4R3oiVnZgManmyxAkGhYeqaV3CQ&oe=64201506"
                },
                new Event
                {
                    Title = "The Equalizer",
                    Description = "Film in the cinema",
                    StartDate = DateTimeOffset.UtcNow.AddDays(3),
                    EndDate = DateTimeOffset.UtcNow.AddDays(15).AddHours(2),
                    Status = true,
                    Approved = true,
                    CreatedAt = DateTimeOffset.UtcNow,
                    Location = "Cavea East Point",
                    Price = 25,
                    Quantity = 150,
                    UserId = 6,
                    Image = "https://m.media-amazon.com/images/M/MV5BMTQ2MzE2NTk0NF5BMl5BanBnXkFtZTgwOTM3NTk1MjE@._V1_.jpg"
                },
                new Event
                {
                    Title = "Tbilisi open air",
                    Description = "The mixed funny event",
                    StartDate = DateTimeOffset.UtcNow.AddDays(2),
                    EndDate = DateTimeOffset.UtcNow.AddDays(3).AddHours(2),
                    Status = true,
                    Approved = true,
                    CreatedAt = DateTimeOffset.UtcNow,
                    Location = "",
                    Price = 225,
                    Quantity = 300,
                    UserId = 5,
                    Image ="https://netgazeti.ge/wp-content/uploads/2022/06/DSC05683.jpg"
                },
                new Event
                {
                    Title = "Ufc Fight Nigth Georgia",
                    Description = "Ufc matchups in georgia",
                    StartDate = DateTimeOffset.UtcNow.AddDays(7),
                    EndDate = DateTimeOffset.UtcNow.AddDays(7).AddHours(9),
                    Status = true,
                    Approved = true,
                    CreatedAt = DateTimeOffset.UtcNow,
                    Location = "Dinamo Areana",
                    Price = 300,
                    Quantity = 55_000,
                    UserId =7,
                    Image = "https://www.silive.com/resizer/ftePF-BBpQ9wg94vQruFbzWtKPg=/1280x0/smart/cloudfront-us-east-1.images.arcpublishing.com/advancelocal/4WTCS3X5YNBU3PBPVSTKYORRAQ.jpeg"
                },
                new Event
                {
                    Title = "KFC Food Challenge",
                    Description = "Food challenge in kfc",
                    StartDate = DateTimeOffset.UtcNow.AddDays(1),
                    EndDate = DateTimeOffset.UtcNow.AddDays(1).AddHours(8),
                    Status = true,
                    Approved = true,
                    CreatedAt = DateTimeOffset.UtcNow,
                    Location = "Kfc Paliashvili street",
                    Price = 5,
                    Quantity = 20,
                    UserId = 8,
                    Image= "https://media-cldnry.s-nbcnews.com/image/upload/t_fit-1500w,f_auto,q_auto:best/msnbc/Components/Photos/061113/061113_kfc_logo_vmed5p.jpg"
                }
            };
            foreach (var ev in events)
            {
                if (context.Events.Any(x => x.Title == ev.Title))
                    continue;
                context.Events.Add(ev);
                seeded = true;
            }
        }
    }
}
