using Blog.Application.DTOs;
using Blog.Application.Services;
using Blog.Infrastructure.Repositories.Blog;

namespace Blog.Application
{
    public class BlogService: IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        public BlogService(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<IEnumerable<BlogDto>> GetBlogs(CancellationToken cancellationToken)
        {
            var blogEntities = await _blogRepository.GetBlogs(cancellationToken);

            // TODO: Automapper
            var blogs = new List<BlogDto>();
            return blogs;
        }
    }
}