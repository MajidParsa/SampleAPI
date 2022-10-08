using Blog.Infrastructure.Repositories.Entities;

namespace Blog.Infrastructure.Repositories.Blog
{
    public class BlogRepository : IBlogRepository
    {
        private static List<BlogEntity> _blogs;

        static BlogRepository()
        {
            _blogs = new List<BlogEntity>
            {
                new BlogEntity() { Id = 1, Name = "Blog 1", Description = "Description 1" },
                new BlogEntity() { Id = 2, Name = "Blog 2", Description = "Description 2" }
            };
        }

        public async Task<IEnumerable<BlogEntity>> GetBlogs(CancellationToken cancellationToken)
        {
            return await Task.Run(() => _blogs, cancellationToken);
        }

        public async Task<BlogEntity> InsertBlog(BlogEntity blogEntity, CancellationToken cancellationToken)
        {
            _blogs.Add(blogEntity);
            return await Task.Run(() => blogEntity, cancellationToken);
        }
    }
}
