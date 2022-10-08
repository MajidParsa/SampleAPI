using AutoMapper;
using Blog.Application.DTOs;
using Blog.Application.Services;
using Blog.Infrastructure.Repositories.Blog;

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
            var blogEntities = await _blogRepository.SelectBlogs(cancellationToken);
            
            var blogs = _mapper.Map<List<BlogDto>>(blogEntities.ToList());
            
            return blogs;
        }

        public async Task<BlogDto> AddBlog(BlogInsertCommand blogInsertCommand, CancellationToken cancellationToken)
        {
            var blogId = await GetMaxBlogId(cancellationToken);
            var blog = Domain.AggregatesModel.Blog.Create(blogId, blogInsertCommand.Name, blogInsertCommand.Description, 1); // NOTE: Just for DDD demo

            var insertedBlog = await _blogRepository.InsertBlog(blog, cancellationToken);

            var result = _mapper.Map<BlogDto>(insertedBlog);
            return result;
        }

        public async Task<BlogDto?> EditBlog(BlogUpdateCommand blogUpdateCommand, CancellationToken cancellationToken)
        {
            var existsBlog = await _blogRepository.SelectBlog(blogUpdateCommand.Id, cancellationToken);
            if (existsBlog == null)
                return null;

            var blogEntity = _mapper.Map(blogUpdateCommand, existsBlog); // TODO: Reference update
            var updatedBlog = await _blogRepository.UpdateBlog(blogEntity, cancellationToken);

            var result = _mapper.Map<Domain.AggregatesModel.Blog, BlogDto>(updatedBlog);
            return result;
        }

        private async Task<int> GetMaxBlogId(CancellationToken cancellationToken)
        {
            // TODO: We should use auto identity column or GUID

            var blogs = await _blogRepository.SelectBlogs(cancellationToken);
            var lastBlog = blogs.MaxBy(i => i.Id);

            return lastBlog == null ? 1 : lastBlog.Id + 1;
        }
    }
}