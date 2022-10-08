using Blog.Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Repositories.EF.EntityConfigs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Username).IsRequired().HasMaxLength(50);
            builder.Property(c => c.PasswordHash).IsRequired().HasMaxLength(4000);
        }
    }
}
