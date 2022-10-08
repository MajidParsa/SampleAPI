using Blog.Domain.SeedWork;

namespace Blog.Domain.AggregatesModel
{
    public class Comment : BaseEntity
    {
        public int PostId { get; private set; }
        public int CreatorId { get; private set; }
        public string Content { get; private set; }
        public DateTime CreateDate { get; private set; }
        public ICollection<Post> Posts { get; private set; }
        public User Creator { get; private set; }

        private Comment(int id, int postId, int creatorId, string content, DateTime createDate)
        {
            if (id > 0)
                Id = id;

            Content = !string.IsNullOrWhiteSpace(content) ? content :
                throw new ArgumentException("Content is not valid");

            PostId = postId > 0 ? postId :
                throw new ArgumentException("The PostId parameter must be greater than zero");

            CreatorId = creatorId > 0 ? creatorId :
                throw new ArgumentException("The CreatorId parameter must be greater than zero");

            CreateDate = createDate;
        }

        public static Comment Put(int id, int postId, int creatorId, string content)
        {
            return new Comment(id, postId, creatorId, content, DateTime.Now);
        }
    }
}
