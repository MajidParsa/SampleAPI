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

        [HttpGet(nameof(GetBlogsAsync))]
        public async Task<ActionResult<BlogDto>> GetBlogsAsync(CancellationToken cancellationToken)
        {
            var result = await _blogService.GetBlogs(cancellationToken);

            return Ok(result);
        }

        [HttpPost(nameof(AddBlogAsync))]
        public async Task<ActionResult<BlogDto>> AddBlogAsync(BlogInsertCommand blogInsertCommand, CancellationToken cancellationToken)
        {
            var result = await _blogService.AddBlog(blogInsertCommand, cancellationToken);

            return Ok(result);
        }

        [HttpPut(nameof(EditBlogAsync))]
        public async Task<ActionResult<BlogDto>> EditBlogAsync(BlogUpdateCommand blogUpdateCommand, CancellationToken cancellationToken)
        {
            var result = await _blogService.EditBlog(blogUpdateCommand, cancellationToken);
            if (result == null)
                return BadRequest("Update failed. Record not found!");

            return Ok(result);
        }

    }
}
