using NUnit.Framework;

namespace Blog.Test.Domain
{
    public class BlogDomainTest
    {
        private const int VALID_BLOG_ID = 1;

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        public async Task CreateBlog_InvalidBlogName_ShouldBeThrowAnException(string name)
        {
            Assert.Throws<ArgumentException>(() => Blog.Domain.AggregatesModel.Blog.Create(VALID_BLOG_ID, name, string.Empty));
        }
    }
}
