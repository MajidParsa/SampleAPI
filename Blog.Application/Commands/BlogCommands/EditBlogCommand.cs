using Blog.Application.DTOs;
using FluentValidation;
using MediatR;

namespace Blog.Application.Commands.BlogCommands
{
    public class EditBlogCommand : IRequest<BlogPostDto>
    {
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public int PostId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }

    public class EditEventCommandValidator : AbstractValidator<EditBlogCommand>
    {
        public EditEventCommandValidator()
        {
            RuleFor(c => c.UserId).NotNull();
            RuleFor(c => c.BlogId).NotNull();
        }
    }
}
