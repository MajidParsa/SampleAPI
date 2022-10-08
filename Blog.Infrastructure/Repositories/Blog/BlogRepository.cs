
namespace Blog.Infrastructure.Repositories.Blog
{
    public class BlogRepository : IBlogRepository
    {
        private static List<Domain.AggregatesModel.Blog> _blogs;

        static BlogRepository()
        {
            /****************************************************************************************************************
             * As a demo project:                                                                                           *
             * Instead of using EF and connecting with the database, I used a static constructor to initialize the records. *
             ****************************************************************************************************************/
            _blogs = new List<Domain.AggregatesModel.Blog>
            {
                Domain.AggregatesModel.Blog.Create(1, "Blog 1", "Description 1"),
                Domain.AggregatesModel.Blog.Create(2, "Blog 2", "Description 2")
            };
        }

        public async Task<Domain.AggregatesModel.Blog?> SelectBlog(int id, CancellationToken cancellationToken)
        {
            var blog = _blogs.FirstOrDefault(i => i.Id == id);
            return await Task.Run(() => blog, cancellationToken);
        }

        public async Task<IEnumerable<Domain.AggregatesModel.Blog>> SelectBlogs(CancellationToken cancellationToken)
        {
            return await Task.Run(() => _blogs, cancellationToken);
        }

        public async Task<Domain.AggregatesModel.Blog> InsertBlog(Domain.AggregatesModel.Blog blog, CancellationToken cancellationToken)
        {
            _blogs.Add(blog);
            return await Task.Run(() => blog, cancellationToken);
        }

        public async Task<Domain.AggregatesModel.Blog> UpdateBlog(Domain.AggregatesModel.Blog blog, CancellationToken cancellationToken)
        {
            _ = _blogs.Remove(_blogs.First(i => i.Id == blog.Id));
            _blogs.Add(blog);
            return await Task.Run(() => blog, cancellationToken);
        }
    }
}
