using ItAcademy.Domain.EventsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItAcademy.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property<int>(i => i.UserId);
            builder.HasOne(i => i.User).WithMany(i => i.Events).HasForeignKey(i => i.UserId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(i => i.Orders).WithOne(i => i.Event).HasForeignKey(i => i.EventId).OnDelete(DeleteBehavior.NoAction);     
        }
    }
}
