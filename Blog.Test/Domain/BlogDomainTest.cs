using NUnit.Framework;

namespace Blog.Test.Domain
{
    public class BlogDomainTest
    {
        private const int VALID_BLOG_ID = 1;
        private const string VALID_BLOG_NAME = "Tech";

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public async Task CreateBlog_InvalidBlogId_ShouldBeThrowAnException(int id)
        {
            Assert.Throws<ArgumentException>(() => Blog.Domain.AggregatesModel.Blog.CreateBlog(id, VALID_BLOG_NAME, string.Empty));
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        public async Task CreateBlog_InvalidBlogName_ShouldBeThrowAnException(string name)
        {
            Assert.Throws<ArgumentException>(() => Blog.Domain.AggregatesModel.Blog.CreateBlog(VALID_BLOG_ID, name, string.Empty));
        }
    }
}
