using Blog.Application.DTOs;
using FluentValidation;
using MediatR;

namespace Blog.Application.Commands.PostCommand
{
    public class AddPostCommand : IRequest<BlogPostDto>
    {
        public int BlogId { get; set; }
        public string Content { get; set; }

    }

    public class AddPostCommandValidator : AbstractValidator<AddPostCommand>
    {
        public AddPostCommandValidator()
        {
            RuleFor(c => c.BlogId).NotNull();
            RuleFor(c => c.Content).NotNull().NotEmpty();
        }
    }
}
