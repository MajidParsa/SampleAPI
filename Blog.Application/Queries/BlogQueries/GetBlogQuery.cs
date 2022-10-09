using Blog.Application.DTOs;
using FluentValidation;
using MediatR;

namespace Blog.Application.Queries.BlogQueries
{
    public class GetBlogQuery : IRequest<IEnumerable<BlogPostDto>>
    {
        public int? Id{ get; set; }
    }
}
