using AutoMapper;
using Blog.Application.DTOs;
using Blog.Domain.AggregatesModel;
using Blog.Infrastructure.Repositories.Blog;
using MediatR;

namespace Blog.Application.Commands.PostCommand
{
    public class AddPostCommandHandler : IRequestHandler<AddPostCommand, BlogPostDto>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;

        public AddPostCommandHandler(IMapper mapper, IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException(nameof(blogRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BlogPostDto> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            var userId = User.CurrentUser().Id;
            Domain.AggregatesModel.Blog? blogInstance = (await _blogRepository.SelectBlogsAsync(request.BlogId, userId, cancellationToken)).FirstOrDefault();
            BlogValidation(blogInstance);

            var postInstance = Post.Add(request.Content, blogInstance.Id);
            blogInstance?.AddPost(postInstance);

            await _blogRepository.UpdateAsync(blogInstance, cancellationToken);

            var blogPostDto = _mapper.Map<BlogPostDto>(blogInstance);

            return blogPostDto;
        }

        private static void BlogValidation(Domain.AggregatesModel.Blog? blogInstance)
        {
            if (blogInstance == null)
                throw new NullReferenceException("Blog not found.");
        }
    }
}
