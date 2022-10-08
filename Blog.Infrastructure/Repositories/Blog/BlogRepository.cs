using Blog.Infrastructure.Repositories.Entities;

namespace Blog.Infrastructure.Repositories.Blog
{
    public class BlogRepository : IBlogRepository
    {
        private static List<BlogEntity> _blogs;

        static BlogRepository()
        {
            /****************************************************************************************************************
             * As a demo project:                                                                                           *
             * Instead of using EF and connecting with the database, I used a static constructor to initialize the records. *
             ****************************************************************************************************************/
            _blogs = new List<BlogEntity>
            {
                new BlogEntity() { Id = 1, Name = "Blog 1", Description = "Description 1" },
                new BlogEntity() { Id = 2, Name = "Blog 2", Description = "Description 2" }
            };
        }

        public async Task<BlogEntity?> SelectBlog(int id, CancellationToken cancellationToken)
        {
            var blog = _blogs.FirstOrDefault(i => i.Id == id);
            return await Task.Run(() => blog, cancellationToken);
        }

        public async Task<IEnumerable<BlogEntity>> SelectBlogs(CancellationToken cancellationToken)
        {
            return await Task.Run(() => _blogs, cancellationToken);
        }

        public async Task<BlogEntity> InsertBlog(BlogEntity blogEntity, CancellationToken cancellationToken)
        {
            _blogs.Add(blogEntity);
            return await Task.Run(() => blogEntity, cancellationToken);
        }

        public async Task<BlogEntity> UpdateBlog(BlogEntity blogEntity, CancellationToken cancellationToken)
        {
            _ = _blogs.Remove(_blogs.First(i => i.Id == blogEntity.Id));
            _blogs.Add(blogEntity);
            return await Task.Run(() => blogEntity, cancellationToken);
        }
    }
}
