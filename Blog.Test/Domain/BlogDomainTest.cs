using NUnit.Framework;

namespace Blog.Test.Domain
{
    public class BlogDomainTest
    {
        [Test]
        [TestCase("")]
        [TestCase(" ")]
        public async Task CreateBlog_InvalidBlogName_ShouldBeThrowAnException(string name)
        {
            Assert.Throws<ArgumentException>(() => Blog.Domain.AggregatesModel.Blog.Create( name, string.Empty, 1));
        }
    }
}
