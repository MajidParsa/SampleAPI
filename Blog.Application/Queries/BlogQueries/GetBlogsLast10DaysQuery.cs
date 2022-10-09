using Blog.Application.DTOs;
using MediatR;

namespace Blog.Application.Queries.BlogQueries
{
    public class GetBlogsLast10DaysQuery : IRequest<IEnumerable<BlogsDto>>
    {
    }
}
