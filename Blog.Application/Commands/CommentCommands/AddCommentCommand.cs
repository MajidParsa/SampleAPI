using Blog.Application.DTOs;
using FluentValidation;
using MediatR;

namespace Blog.Application.Commands.CommentCommands
{
    public class AddCommentCommand : IRequest<BlogPostDto>
    {
        public int BlogId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }

    public class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
    {
        public AddCommentCommandValidator()
        {
            RuleFor(c => c.Content).NotNull().NotEmpty();
            RuleFor(c => c.BlogId).NotNull().NotEmpty();
            RuleFor(c => c.PostId).NotNull().NotEmpty();
            RuleFor(c => c.UserId).NotNull().NotEmpty();
        }
    }
}
