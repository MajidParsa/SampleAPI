using Blog.Application.Commands.CommentCommands;
using Blog.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blog.API.Controllers
{
    public class CommentController : BaseApiController
    {
        private readonly ILogger<CommentController> _logger;

        public CommentController(ILogger<CommentController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost(nameof(AddCommentAsync))]
        public async Task<ActionResult<BlogPostDto>> AddCommentAsync(AddCommentCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Request => {JsonConvert.SerializeObject(command)}");

            var result = await Mediator.Send(command, cancellationToken);

            _logger.LogInformation($"Response => {JsonConvert.SerializeObject(result)}");

            return Ok(result);
        }

    }
}
