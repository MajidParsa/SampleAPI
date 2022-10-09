using Blog.Domain.AggregatesModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Repositories.EF.EntityConfigs
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Content).IsRequired().HasMaxLength(4000);
            //builder.Property(c => c.BlogId).IsRequired();
        }
    }
}
