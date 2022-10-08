using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Infrastructure.Repositories.EF.EntityConfigs
{
    public class BlogConfig : IEntityTypeConfiguration<Domain.AggregatesModel.Blog>
    {
        public void Configure(EntityTypeBuilder<Domain.AggregatesModel.Blog> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).IsRequired().HasMaxLength(1000);
            builder.HasOne(p => p.Creator).WithMany(c => c.Blogs).HasForeignKey(p => p.CreatorId);
        }
    }
}
