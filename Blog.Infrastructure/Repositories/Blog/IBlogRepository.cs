using Blog.Infrastructure.Repositories.Entities;

namespace Blog.Infrastructure.Repositories.Blog
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogEntity>> GetBlogs(CancellationToken cancellationToken);
        Task<BlogEntity> InsertBlog(BlogEntity blogEntity, CancellationToken cancellationToken);
    }
}
