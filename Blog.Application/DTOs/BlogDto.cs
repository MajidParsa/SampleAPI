﻿using Blog.Domain.AggregatesModel;

namespace Blog.Application.DTOs
{
    public class BlogDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public ICollection<Post> Posts { get; private set; }

    }
}
