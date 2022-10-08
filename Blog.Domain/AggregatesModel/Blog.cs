using Blog.Domain.SeedWork;

namespace Blog.Domain.AggregatesModel
{
    public class Blog: BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int CreatorId { get; private set; }
        public User Creator { get; private set; }
        public ICollection<Post> Posts { get; private set; }

        private Blog(int id, string name, string description, int creatorId)
        {
            if (id > 0)
                Id = id;

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The Name field must not be empty");

            Name = name;
            Description = description;
            CreatorId = creatorId;
        }

        public static Blog Create(int id, string name, string description, int creatorId)
        {
            return new Blog(id, name, description, creatorId);
        }

    }
}
