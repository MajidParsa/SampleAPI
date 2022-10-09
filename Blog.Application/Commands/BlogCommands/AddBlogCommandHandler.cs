using AutoMapper;
using AutoMapper.QueryableExtensions;
using Blog.Application.DTOs;
using Blog.Domain.AggregatesModel;
using Blog.Infrastructure.Repositories.Blog;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Blog.Application.Commands.BlogCommands
{
    public class AddBlogCommandHandler : IRequestHandler<AddBlogCommand, BlogDto>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;

        public AddBlogCommandHandler(IMapper mapper, IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException(nameof(blogRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BlogDto> Handle(AddBlogCommand request, CancellationToken cancellationToken)
        {
            int userId = 1;
            var blogInstance = Domain.AggregatesModel.Blog.Create( request.Name, request.Description, userId);

            var postInstance = Post.Create(request.Content, blogInstance.Id);
            blogInstance = Domain.AggregatesModel.Blog.PublishPost(blogInstance, postInstance);

            await _blogRepository.AddAsync(blogInstance, cancellationToken);

            var blogDto = _mapper.Map<BlogDto>(blogInstance);

            return blogDto;
        }
    }
}
