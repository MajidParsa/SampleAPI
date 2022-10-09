using AutoMapper;
using Blog.Application.DTOs;
using Blog.Domain.AggregatesModel;
using Blog.Infrastructure.Repositories.Blog;
using MediatR;

namespace Blog.Application.Queries.BlogQueries
{
    public class GetPostsLast30DaysOfBlogsHandler : IRequestHandler<GetPostsLast30DaysOfBlogsQuery, IEnumerable<BlogPostDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;

        public GetPostsLast30DaysOfBlogsHandler(IMapper mapper, IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException(nameof(blogRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<BlogPostDto>> Handle(GetPostsLast30DaysOfBlogsQuery request, CancellationToken cancellationToken)
        {
            var userId = User.CurrentUser().Id;

            var result = await _blogRepository.SelectPostsLast30DaysOfBlogs(userId, cancellationToken);
            var blogsDto = _mapper.Map<List<BlogPostDto>>(result);

            return blogsDto;
        }
    }
}
