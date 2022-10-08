using Blog.Application.DTOs;
using Blog.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService= blogService;
        }

        [HttpGet("GetBlogsAsync")]
        public async Task<ActionResult<BlogDto>> GetBlogsAsync(CancellationToken cancellationToken)
        {
            var result = await _blogService.GetBlogs(cancellationToken);

            return Ok(result);
        }
    }
}
