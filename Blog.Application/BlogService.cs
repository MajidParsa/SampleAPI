using AutoMapper;
using Blog.Application.DTOs;
using Blog.Infrastructure.Repositories.Blog;

namespace Blog.Application
{
    public class BlogService
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;

        public BlogService(IMapper mapper, IBlogRepository blogRepository)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
        }

        public async Task<IEnumerable<BlogDto>> GetBlogs(CancellationToken cancellationToken)
        {
            var blogEntities = await _blogRepository.SelectBlogsAsync(cancellationToken);
            
            var blogs = _mapper.Map<List<BlogDto>>(blogEntities.ToList());
            
            return blogs;
        }

        public async Task<BlogDto?> EditBlog(BlogUpdateCommand blogUpdateCommand, CancellationToken cancellationToken)
        {
            var existsBlog = await _blogRepository.SelectBlogAsync(blogUpdateCommand.Id, cancellationToken);
            if (existsBlog == null)
                return null;

            var blogEntity = _mapper.Map(blogUpdateCommand, existsBlog); // TODO: Reference update
            var updatedBlog = await _blogRepository.UpdateBlogAsync(blogEntity, cancellationToken);

            var result = _mapper.Map<Domain.AggregatesModel.Blog, BlogDto>(updatedBlog);
            return result;
        }

        private async Task<int> GetMaxBlogId(CancellationToken cancellationToken)
        {
            // TODO: We should use auto identity column or GUID

            var blogs = await _blogRepository.SelectBlogsAsync(cancellationToken);
            var lastBlog = blogs.MaxBy(i => i.Id);

            return lastBlog == null ? 1 : lastBlog.Id + 1;
        }
    }
}