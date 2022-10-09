using Blog.Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Repositories.EF.EntityConfigs
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Content).IsRequired().HasMaxLength(4000);
            builder.Property(c => c.CreatorId).IsRequired();
            builder.Property(c => c.PostId).IsRequired();
        }
    }
}
