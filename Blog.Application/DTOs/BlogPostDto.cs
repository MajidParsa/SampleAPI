using Blog.Domain.AggregatesModel;

namespace Blog.Application.DTOs
{
    public class BlogPostDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int CreatorId { get; set; }
        public ICollection<Post> Posts { get; set; }

    }
}
