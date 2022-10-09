using Blog.Application.Commands.PostCommand;
using Blog.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blog.API.Controllers
{
    public class PostController : BaseApiController
    {
        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        [HttpPost(nameof(AddPostAsync))]
        public async Task<ActionResult<BlogPostDto>> AddPostAsync(AddPostCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Request => {JsonConvert.SerializeObject(command)}");

            var result = await Mediator.Send(command, cancellationToken);

            _logger.LogInformation($"Response => {JsonConvert.SerializeObject(result)}");

            return Ok(result);
        }
    }
}
