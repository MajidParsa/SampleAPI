using Blog.Application.Commands.BlogCommands;
using Blog.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blog.API.Controllers
{
    public class BlogController : BaseApiController
    {
      
        private readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger)
        {
           
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet(nameof(GetBlogsAsync))]
        public async Task<ActionResult<BlogDto>> GetBlogsAsync(CancellationToken cancellationToken)
        {
            //var result = await _blogService.GetBlogs(cancellationToken);

            return Ok(null);
        }

        [HttpPost(nameof(AddBlogAsync))]
        public async Task<ActionResult<BlogDto>> AddBlogAsync(AddBlogCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Request => {JsonConvert.SerializeObject(command)}");
            
            var result = await Mediator.Send(command, cancellationToken);

            _logger.LogInformation($"Response => {JsonConvert.SerializeObject(result)}");

            return Ok(result);
        }

        [HttpPut(nameof(EditBlogAsync))]
        public async Task<ActionResult<BlogDto>> EditBlogAsync(BlogUpdateCommand blogUpdateCommand, CancellationToken cancellationToken)
        {
            //_logger.LogInformation($"Request => {JsonConvert.SerializeObject(blogUpdateCommand)}");

            //var result = await _blogService.EditBlog(blogUpdateCommand, cancellationToken);
            
            //_logger.LogInformation($"Response => {JsonConvert.SerializeObject(result)}");

            //if (result == null)
            //    return BadRequest("Update failed. Record not found!");

            return Ok(null);
        }

    }
}
