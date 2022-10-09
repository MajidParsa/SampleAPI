using Blog.Domain.AggregatesModel;
using Blog.Domain.SeedWork;

namespace Blog.Infrastructure.Repositories.Blog
{
    public interface IBlogRepository : IRepository<Domain.AggregatesModel.Blog>
    {
        Task PutCommentAsync(Domain.AggregatesModel.Blog blog, Post post, CancellationToken cancellationToken, bool saveNow = true);
        Task<IEnumerable<Domain.AggregatesModel.Blog>> SelectBlogsAsync(int? blogId, int userId, CancellationToken cancellationToken);
        Task UpdateBlogAsync(Domain.AggregatesModel.Blog blog, Post post, CancellationToken cancellationToken, bool saveNow = true);
        Task<IEnumerable<Domain.AggregatesModel.Blog>> SelectBlogsLast10Days(int userId, CancellationToken cancellationToken);
        Task<IEnumerable<Domain.AggregatesModel.Blog>> SelectPostsLast30DaysOfBlogs(int userId, CancellationToken cancellationToken);
    }
}
