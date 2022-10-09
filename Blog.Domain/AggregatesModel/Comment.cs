using Blog.Domain.SeedWork;

namespace Blog.Domain.AggregatesModel
{
    public class Comment : BaseEntity
    {
        public int PostId { get; private set; }
        public int CreatorId { get; private set; }
        public string Content { get; private set; }
        public DateTime CreateDate { get; private set; }
        public Post Post { get; private set; }
        public User Creator { get; private set; }

        private Comment(int id, int postId, int creatorId, string content, DateTime createDate)
        {
            Content = !string.IsNullOrWhiteSpace(content) ? content :
                throw new ArgumentException("Content is not valid");

            PostId = postId > 0 ? postId :
                throw new ArgumentException("The PostId parameter must be greater than zero");

            CreatorId = creatorId > 0 ? creatorId :
                throw new ArgumentException("The CreatorId parameter must be greater than zero");

            Id = id;
            CreateDate = createDate;
        }

        public static Comment Create(int id, int postId, int creatorId, string content)
        {
            return new Comment(id, postId, creatorId, content, DateTime.Now);
        }

        public static Comment Create(int postId, int creatorId, string content)
        {
            return Create(0, postId, creatorId, content);
        }
    }
}
