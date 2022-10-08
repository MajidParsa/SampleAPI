namespace Blog.Infrastructure.Repositories.Blog
{
    public interface IBlogRepository
    {
        Task<Domain.AggregatesModel.Blog?> SelectBlog(int id, CancellationToken cancellationToken);
        Task<IEnumerable<Domain.AggregatesModel.Blog>> SelectBlogs(CancellationToken cancellationToken);
        Task<Domain.AggregatesModel.Blog> InsertBlog(Domain.AggregatesModel.Blog blog, CancellationToken cancellationToken);
        Task<Domain.AggregatesModel.Blog> UpdateBlog(Domain.AggregatesModel.Blog blog, CancellationToken cancellationToken);
    }
}
