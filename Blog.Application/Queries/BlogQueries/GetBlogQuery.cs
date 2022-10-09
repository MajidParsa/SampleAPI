using Blog.Application.DTOs;
using FluentValidation;
using MediatR;

namespace Blog.Application.Queries.BlogQueries
{
    public class GetBlogQuery : IRequest<IEnumerable<BlogPostsDto>>
    {
        public int? Id{ get; set; }
    }
}
