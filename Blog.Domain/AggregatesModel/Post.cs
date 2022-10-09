using Blog.Domain.SeedWork;

namespace Blog.Domain.AggregatesModel
{
    public class Post: BaseEntity
    {
        public string Content { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        public int BlogId { get; private set; }
        public Blog Blog { get; private set; }
        public ICollection<Comment> Comments { get; private set; }

        private Post(int id, string content, int blogId, DateTime createDate)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("The Content field must not be empty");

            Id = id;
            Content = content;
            BlogId = blogId;
            CreateDate = createDate;
        }

        public static Post Create(int id, string content, int blogId)
        {
            return new Post(id, content, blogId, DateTime.Now);
        }
        public static Post Create(string content, int blogId)
        {
            return Create(0, content, blogId);
        }

        public static void Edit(Post postInstance, string content)
        {
            postInstance.Content = content;
            postInstance.UpdateDate = DateTime.Now;
        }

        public static void PutComment(Post postInstance, Comment comment)
        {
            postInstance.Comments.Add(comment);
        }
    }
}
