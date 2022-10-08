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
    }
}