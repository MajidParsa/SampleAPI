using AutoMapper;
using Blog.Application.DTOs;
using Blog.Domain.AggregatesModel;
using Blog.Infrastructure.Repositories.Blog;
using MediatR;

namespace Blog.Application.Commands.BlogCommands
{
    public class EditBlogCommandHandler : IRequestHandler<EditBlogCommand, BlogDto>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;

        public EditBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException(nameof(blogRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BlogDto> Handle(EditBlogCommand request, CancellationToken cancellationToken)
        {
            var userId = User.CurrentUser().Id;
            Domain.AggregatesModel.Blog? blogInstance = (await _blogRepository.SelectBlogsAsync(request.BlogId, userId, cancellationToken)).FirstOrDefault();
            BlogValidation(blogInstance);

            request.Name = string.IsNullOrWhiteSpace(request.Name) ? blogInstance.Name : request.Name;
            Domain.AggregatesModel.Blog.Edit(blogInstance, request.Name, request.Description);

            if (request.PostId > 0 && !string.IsNullOrWhiteSpace(request.Content))
            {
                var post = blogInstance.Posts.First(p => p.Id == request.PostId);
                Post.Edit(post, request.Content);
            }

            await _blogRepository.UpdateAsync(blogInstance, cancellationToken);

            var blogDto = _mapper.Map<BlogDto>(blogInstance);
            return blogDto;
        }

        private static void BlogValidation(Domain.AggregatesModel.Blog? blogInstance)
        {
            if (blogInstance == null)
                throw new NullReferenceException("Blog not found.");
        }
    }
}
