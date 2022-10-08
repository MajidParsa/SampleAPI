using Blog.Domain.SeedWork;

namespace Blog.Domain.AggregatesModel
{
    public class Post: BaseEntity
    {
        public string Content { get; private set; }
        public DateTime CreateDate { get; private set; }
        public int BlogId { get; private set; }
        public Blog Blog { get; private set; }

        private Post(int id, string content, int blogId, DateTime createDate)
        {
            if (id > 0)
                Id = id;

            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("The Content field must not be empty");

            if (blogId < 1)
                throw new ArgumentException("The BlogId parameter must be greater than zero");

            Content = content;
            BlogId = blogId;
            CreateDate = createDate;
        }

        public static Post Publish(int id, string content, int blogId)
        {
            return new Post(id, content, blogId, DateTime.Now);
        }
    }
}
