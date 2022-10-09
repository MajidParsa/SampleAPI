namespace Blog.Application.DTOs
{
    public class CommentDto
    {
        public int BlogId { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
