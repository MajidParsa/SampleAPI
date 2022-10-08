using System.Reflection;
using Blog.Domain.AggregatesModel;
using Blog.Domain.SeedWork;
using Blog.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories.EF
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entitiesAssembly = typeof(IEntity).Assembly;
            modelBuilder.RegisterAllEntities<IEntity>(entitiesAssembly);
            modelBuilder.AddRestrictDeleteBehaviorConvention();
            modelBuilder.AddPluralizingTableNameConvention();
            modelBuilder.RegisterEntityTypeConfiguration(Assembly.GetExecutingAssembly());

            AddSeedData(modelBuilder);
        }

        public void AddSeedData(ModelBuilder modelBuilder)
        {
            var passwordHash = SecurityHelper.GetSha256Hash("123456");
            modelBuilder.Entity<User>().HasData(
                User.Create(1, "Majid", passwordHash));

            modelBuilder.Entity<Domain.AggregatesModel.Blog>().HasData(
                Domain.AggregatesModel.Blog.Create(1, "Blog 1", "Description 1", 1),
                Domain.AggregatesModel.Blog.Create(2, "Blog 2", "Description 2", 1),
                Domain.AggregatesModel.Blog.Create(3, "Blog 3", "Description 3", 1),
                Domain.AggregatesModel.Blog.Create(4, "Blog 4", "Description 4", 1));

            modelBuilder.Entity<Post>().HasData(
                Post.Publish(1, "Post 1", 1),
                Post.Publish(2, "Post 2", 1),
                Post.Publish(3, "Post 3", 2),
                Post.Publish(4, "Post 4", 1));

            modelBuilder.Entity<Comment>().HasData(
                Comment.Put(1, 1, 1, "Comment 1"),
                Comment.Put(2, 1, 1, "Comment 2"),
                Comment.Put(3, 1, 1, "Comment 3"),
                Comment.Put(4, 2, 1, "Comment 4"));
        }
    }
}
