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

        private readonly List<Post> _posts;
        public IReadOnlyCollection<Post> Posts => _posts;

        private Blog(int id, string name, string description, int creatorId, DateTime createDate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The Name field must not be empty");

            Id = id;
            Name = name;
            Description = description;
            CreatorId = creatorId;
            CreateDate = createDate;
            _posts = new List<Post>();
        }

        public Blog()
        {
            _posts = new List<Post>();
        }

        public static Blog Add(int id, string name, string description, int creatorId)
        {
            return new Blog(id, name, description, creatorId, DateTime.Now);
        }
        public static Blog Add(string name, string description, int creatorId)
        {
            return Add(0, name, description, creatorId);
        }


        public void Edit(string name, string description)
        {
            Name = name;
            UpdateDate = DateTime.Now;
            Description = description;
        }

        public void AddPost(Post post)
        {
            _posts.Add(post);
        }
    }
}
