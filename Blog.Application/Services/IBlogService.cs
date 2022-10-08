using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.DTOs;

namespace Blog.Application.Services
{
    public interface IBlogService
    {
        Task<IEnumerable<BlogDto>> GetBlogs(CancellationToken cancellationToken);
    }
}
