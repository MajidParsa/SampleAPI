using Blog.Domain.AggregatesModel;

namespace Blog.Application.DTOs
{
    public class BlogsDto
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
