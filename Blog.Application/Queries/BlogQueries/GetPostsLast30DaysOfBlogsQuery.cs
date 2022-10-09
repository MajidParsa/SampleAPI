using Blog.Application.DTOs;
using MediatR;

namespace Blog.Application.Queries.BlogQueries
{
    public class GetPostsLast30DaysOfBlogsQuery : IRequest<IEnumerable<BlogPostDto>>
    {
    }
}
