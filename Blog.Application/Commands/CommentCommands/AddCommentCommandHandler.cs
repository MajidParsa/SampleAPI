﻿using AutoMapper;
using Blog.Application.DTOs;
using Blog.Domain.AggregatesModel;
using Blog.Infrastructure.Repositories.Blog;
using MediatR;

namespace Blog.Application.Commands.CommentCommands
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, CommentDto>
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;

        public AddCommentCommandHandler(IMapper mapper, IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException(nameof(blogRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<CommentDto> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            User user = User.CurrentUser();

            var blog = await _blogRepository.GetByIdAsync(cancellationToken, request.BlogId);
            ValidateBlog(blog);

            var post = blog.Posts.First(p => p.Id == request.PostId);

            var commentInstance = Comment.Create(post.Id, user.Id, request.Content);
            post = Post.PutComment(post, commentInstance);


            await _blogRepository.PutCommentAsync(blog, post, cancellationToken);

            var commentDto = _mapper.Map<CommentDto>(blog);

            return commentDto;
        }

        private static void ValidateBlog(Domain.AggregatesModel.Blog blogInstance)
        {
            if (blogInstance == null)
                throw new NullReferenceException("Blog not found.");
        }
    }
}