using AutoMapper;
using Blog.Application.DTOs;
using Blog.Domain.AggregatesModel;
using Blog.Infrastructure.Repositories.Blog;
using MediatR;

namespace Blog.Application.Queries.BlogQueries
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, IEnumerable<BlogsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;

        public GetBlogQueryHandler(IMapper mapper, IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException(nameof(blogRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<IEnumerable<BlogsDto>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var userId = User.CurrentUser().Id;

            if (request.Id < 1) request.Id = null;
            var result = await _blogRepository.SelectBlogsAsync(request.Id, userId, cancellationToken);
            var blogsDto = _mapper.Map<List<BlogsDto>>(result);

            return blogsDto;
        }
    }
}
