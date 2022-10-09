using Blog.Domain.AggregatesModel;
using Blog.Domain.SeedWork;

namespace Blog.Infrastructure.Repositories.Blog
{
    public interface IBlogRepository : IRepository<Domain.AggregatesModel.Blog>
    {
        //Task<Domain.AggregatesModel.Blog?> SelectBlogAsync(int id, CancellationToken cancellationToken);
        //Task<IEnumerable<Domain.AggregatesModel.Blog>> SelectBlogsAsync(CancellationToken cancellationToken);
        //Task<Domain.AggregatesModel.Blog> UpdateBlogAsync(Domain.AggregatesModel.Blog blog, CancellationToken cancellationToken);
        Task PutCommentAsync(Domain.AggregatesModel.Blog blog, Post post, CancellationToken cancellationToken, bool saveNow = true);
    }
}
