using ItAcademy.Domain.ArchiveAggregate;
using ItAcademy.Domain.EventsAggregate;
using ItAcademy.Domain.OrderAggregate;
using ItAcademy.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace ItAcademy.Persistence.DataContext
{
    public class ItAcademyDbContext : DbContext
    {
        public ItAcademyDbContext(DbContextOptions<ItAcademyDbContext> options): base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Archive> Archives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItAcademyDbContext).Assembly);
        }
    }
}
