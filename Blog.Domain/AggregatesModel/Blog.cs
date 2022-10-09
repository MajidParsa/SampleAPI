using Blog.Domain.SeedWork;

namespace Blog.Domain.AggregatesModel
{
    public class Blog: BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        public int CreatorId { get; private set; }
        public User Creator { get; private set; }
        public ICollection<Post> Posts { get; private set; }

        private Blog(int id, string name, string description, int creatorId, DateTime createDate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The Name field must not be empty");

            Id = id;
            Name = name;
            Description = description;
            CreatorId = creatorId;
            CreateDate = createDate;
            Posts = new List<Post>();
        }

        public static Blog Create(int id, string name, string description, int creatorId)
        {
            return new Blog(id, name, description, creatorId, DateTime.Now);
        }
        public static Blog Create(string name, string description, int creatorId)
        {
            return Create(0, name, description, creatorId);
        }


        public static void Edit(Blog blogInstance, string name, string description)
        {
            blogInstance.Name = name;
            blogInstance.UpdateDate = DateTime.Now;
            blogInstance.Description = description;
        }

        public static void PublishPost(Blog blogInstance, Post post)
        {
            blogInstance.Posts.Add(post);
        }
    }
}
