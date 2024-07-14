using ItAcademy.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItAcademy.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(i => i.UserName).IsUnique();
            builder.HasIndex(i => i.Email).IsUnique();
            builder.HasMany(i => i.Orders).WithOne(i => i.User).HasForeignKey(i => i.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
