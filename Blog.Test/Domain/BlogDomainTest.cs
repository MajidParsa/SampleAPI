using Blog.Domain.AggregatesModel;
using NUnit.Framework;

namespace Blog.Test.Domain
{
    public class BlogDomainTest
    {
        [Test]
        public void Add_ValidInputs_BlogShouldBeReturned()
        {
            // Arrange
            var name = "Test";
            var description = "des";
            var creatorId = 1;

            // Act
            Blog.Domain.AggregatesModel.Blog blog = Blog.Domain.AggregatesModel.Blog.Add(name, description, creatorId);

            // Assert
            Assert.IsNotNull(blog);
            Assert.AreEqual(name, blog.Name);
            Assert.AreEqual(description, blog.Description);
            Assert.AreEqual(creatorId, blog.CreatorId);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        public void Add_NameIsEmpty_ErrorShouldBeReturned(string name)
        {
            // Arrange
            var description = "des";
            var creatorId = 1;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => Blog.Domain.AggregatesModel.Blog.Add(name, description, creatorId));
        }

        [Test]
        public void AddPost_InvalidPost_BlogHavingOnlyOnePostShouldBeReturned()
        {
            // Arrange
            var content = "test";
            Blog.Domain.AggregatesModel.Blog blog = GetFakeBlog();
            Post post = Post.Add(content, blog.Id);

            // Act
            blog.AddPost(post);

            // Assert
            Assert.AreEqual(blog.Posts.Count(), 1);
        }


        private static Blog.Domain.AggregatesModel.Blog GetFakeBlog()
        {
            return Blog.Domain.AggregatesModel.Blog.Add(1, "blog", "description", 1);
        }
    }
}
