using AutoMapper;
using Blog.Application;
using Blog.Application.Commands.PostCommand;
using Blog.Infrastructure.Repositories.Blog;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace Blog.Test.Application
{
    public class BlogServiceTest
    {
        private readonly Mock<IMapper> _autoMapper;
        private readonly Mock<IBlogRepository> _blogRepository;

        //[SetUp]
        //public void Setup()
        //{
        //    var mockBlogRepository = new Mock<BlogRepository>();
        //    var mockBlogService = new Mock<BlogService>(mockBlogRepository.Object);

        //    _blogService = mockBlogService.Object;
        //}

        public BlogServiceTest()
        {
            _blogRepository = new Mock<IBlogRepository>();
            _autoMapper = new Mock<IMapper>();
        }

        [Test]
        public async Task AddPost_ShouldThrowException_WhenBlogNotFound()
        {
            //var addCommand = new AddPostCommand() {  };
            //_identityService.Setup(x => x.GetUserId()).Returns(() => sampleUserId);
            //_eventRepository.Setup(x => x.GetByIdAsync(It.IsAny<CancellationToken>(), It.IsAny<int>())).Returns(() => Task.FromResult<Event>(null));
            //var handler = new AddExpenseCommandHandler(_eventRepository.Object, _identityService.Object, _autoMapper.Object);

            //var exception = await Assert.ThrowsAsync<ExpenseManagerApplicationServiceException>(async () => await handler.Handle(addCommand, new CancellationToken()));
            //Assert.Equal("Event not found.", exception.Message);
        }
    }
}
