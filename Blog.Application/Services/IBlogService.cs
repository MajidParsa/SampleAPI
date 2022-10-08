using Blog.Application.DTOs;

namespace Blog.Application.Services
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDto>> GetBlogs(CancellationToken cancellationToken);
        Task<BlogDto> AddBlog(BlogInsertCommand blogInsertCommand, CancellationToken cancellationToken);
    }
}
