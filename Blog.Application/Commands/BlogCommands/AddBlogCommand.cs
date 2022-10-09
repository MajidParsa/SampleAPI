using Blog.Application.DTOs;
using FluentValidation;
using MediatR;

namespace Blog.Application.Commands.BlogCommands
{
    public class AddBlogCommand : IRequest<BlogDto>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }

    public class AddBlogCommandValidator : AbstractValidator<AddBlogCommand>
    {
        public AddBlogCommandValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty();
            RuleFor(c => c.Description).NotNull().NotEmpty();
            RuleFor(c => c.Content).NotNull().NotEmpty();
        }
    }
}
