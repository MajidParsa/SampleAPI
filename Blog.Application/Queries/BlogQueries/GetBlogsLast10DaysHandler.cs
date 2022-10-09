using AutoMapper;
using Blog.Application.DTOs;
using Blog.Domain.AggregatesModel;
using Blog.Infrastructure.Repositories.Blog;
using MediatR;

namespace Blog.Application.Queries.BlogQueries
{
    public class GetBlogsLast10DaysHandler : IRequestHandler<GetBlogsLast10DaysQuery, IEnumerable<BlogsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;

        public GetBlogsLast10DaysHandler(IMapper mapper, IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException(nameof(blogRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<BlogsDto>> Handle(GetBlogsLast10DaysQuery request, CancellationToken cancellationToken)
        {
            var userId = User.CurrentUser().Id;

            var result = await _blogRepository.SelectBlogsLast10Days(userId, cancellationToken);
            var blogsDto = _mapper.Map<List<BlogsDto>>(result);

            return blogsDto;
        }
    }
}
