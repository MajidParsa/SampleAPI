using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Infrastructure.Repositories.Entities;

namespace Blog.Infrastructure.Repositories.Blog
{
    public interface IBlogRepository
    {
        Task<IEnumerable<BlogEntity>> GetBlogs(CancellationToken cancellationToken);
    }
}
