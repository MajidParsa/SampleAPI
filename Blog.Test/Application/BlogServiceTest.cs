using AutoMapper;
using Blog.Application.Commands.PostCommand;
using Blog.Application.DTOs;
using Blog.Domain.AggregatesModel;
using Blog.Infrastructure.Repositories.Blog;
using Moq;
using NUnit.Framework;


namespace Blog.Test.Application
{
    public class BlogServiceTest
    {
        private Mock<IMapper> _autoMapper;
        private Mock<IBlogRepository> _blogRepository;

        [SetUp]
        public void Setup()
        {
            _blogRepository = new Mock<IBlogRepository>();
            _autoMapper = new Mock<IMapper>();
        }


        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public async Task AddPost_ShouldThrowException_WhenBlogNotFound(int blogId)
        {
            var addCommand = new AddPostCommand() { BlogId = blogId, Content = "Test" };
            _blogRepository.Setup(x => x
                .GetByIdAsync(It.IsAny<CancellationToken>(), It.IsAny<int>()))
                .Returns(() => Task.FromResult<Blog.Domain.AggregatesModel.Blog>(null));

            var handler = new AddPostCommandHandler(_autoMapper.Object, _blogRepository.Object);

            var exception = Assert.ThrowsAsync<NullReferenceException>(async () => await handler.Handle(addCommand, CancellationToken.None));
            Assert.AreEqual("Blog not found.", exception.Message);
        }

        [Test]
        public async Task AddPost_ShouldWork_WhenParametersAreValid()
        {
            var userId = 1;
            var blogId = 1;
            var content = "Test";
            Blog.Domain.AggregatesModel.Blog blog = Blog.Domain.AggregatesModel.Blog.Add(blogId, "Blog test", "Description test", userId);
            IEnumerable<Blog.Domain.AggregatesModel.Blog> blogInstance = new List<Blog.Domain.AggregatesModel.Blog>() { blog };

            var addCommand = new AddPostCommand() { BlogId = blogId, Content = content };
            var handler = new AddPostCommandHandler(_autoMapper.Object, _blogRepository.Object);
            
            _blogRepository.Setup(x=> x
                .SelectBlogsAsync(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(() => blogInstance);
            blogInstance.First().AddPost(Post.Add(content, blogId));

            BlogPostDto actual = await handler.Handle(addCommand, CancellationToken.None);
            Assert.True(blogInstance.First().Posts.Any());
            Assert.AreEqual(content, blogInstance.First().Posts.Last().Content);
        }
    }
}
