using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Infrastructure.Repositories.Entities;

namespace Blog.Infrastructure.Repositories.Blog
{
    public class BlogRepository: IBlogRepository
    {
        public async Task<IEnumerable<BlogEntity>> GetBlogs(CancellationToken cancellationToken)
        {
            return await Task.Run(() => new List<BlogEntity>() { new BlogEntity() { Id = 1, Name = "Blog 1", Description = "Description 1" } }, cancellationToken);
        }
    }
}
