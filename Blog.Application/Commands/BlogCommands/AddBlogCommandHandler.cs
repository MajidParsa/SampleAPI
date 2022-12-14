using AutoMapper;
using Blog.Application.DTOs;
using Blog.Domain.AggregatesModel;
using Blog.Infrastructure.Repositories.Blog;
using MediatR;

namespace Blog.Application.Commands.BlogCommands
{
    public class AddBlogCommandHandler : IRequestHandler<AddBlogCommand, BlogPostDto>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;

        public AddBlogCommandHandler(IMapper mapper, IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException(nameof(blogRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BlogPostDto> Handle(AddBlogCommand request, CancellationToken cancellationToken)
        {
            var userId = User.CurrentUser().Id;
            var blogInstance = Domain.AggregatesModel.Blog.Add(request.Name, request.Description, userId);

            var postInstance = Post.Add(request.Content, blogInstance.Id);
            blogInstance.AddPost(postInstance);

            await _blogRepository.AddAsync(blogInstance, cancellationToken);

            var blogDto = _mapper.Map<BlogPostDto>(blogInstance);

            return blogDto;
        }
    }
}
