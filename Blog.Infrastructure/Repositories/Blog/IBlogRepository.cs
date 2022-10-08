using Blog.Infrastructure.Repositories.Entities;

namespace Blog.Infrastructure.Repositories.Blog
{
    public interface IBlogRepository
    {
        Task<BlogEntity?> SelectBlog(int id, CancellationToken cancellationToken);
        Task<IEnumerable<BlogEntity>> SelectBlogs(CancellationToken cancellationToken);
        Task<BlogEntity> InsertBlog(BlogEntity blogEntity, CancellationToken cancellationToken);
        Task<BlogEntity> UpdateBlog(BlogEntity blogEntity, CancellationToken cancellationToken);
    }
}
