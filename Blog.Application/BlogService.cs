using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.Services;
using Blog.Infrastructure.Repositories.Blog;
using Blog.Infrastructure.Repositories.Entities;

namespace Blog.Application
{
    public class BlogService: IBlogService
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
            var blogEntities = await _blogRepository.GetBlogs(cancellationToken);
            
            var blogs = _mapper.Map<List<BlogEntity>, List<BlogDto>>(blogEntities.ToList());
            
            return blogs;
        }

        public async Task<BlogDto> AddBlog(BlogInsertCommand blogInsertCommand, CancellationToken cancellationToken)
        {
            var blogId = await GetMaxBlogId(cancellationToken);
            var blog = Domain.AggregatesModel.Blog.CreateBlog(blogId, blogInsertCommand.Name, blogInsertCommand.Description);

            var blogEntity = _mapper.Map<Domain.AggregatesModel.Blog, BlogEntity> (blog);
            var insertedBlog = await _blogRepository.InsertBlog(blogEntity, cancellationToken);

            var result = _mapper.Map<BlogEntity, BlogDto>(insertedBlog);
            return result;
        }

        private async Task<int> GetMaxBlogId(CancellationToken cancellationToken)
        {
            // TODO: We should use auto identity column or GUID

            var blogs = await _blogRepository.GetBlogs(cancellationToken);
            var lastBlog = blogs.MaxBy(i => i.Id);

            return lastBlog == null ? 1 : ++lastBlog.Id;
        }
    }
}