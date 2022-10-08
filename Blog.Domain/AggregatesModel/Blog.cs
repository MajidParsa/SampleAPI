namespace Blog.Domain.AggregatesModel
{
    public class Blog
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        private Blog(int id, string name, string description)
        {
            if (id < 1)
                throw new ArgumentException("The Id field must be greater than zero.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The Name field must not be empty");

            Id = id;
            Name = name;
            Description = description;
        }

        public static Blog CreateBlog(int id, string name, string description)
        {
            return new Blog(id, name, description);
        }
    }
}
