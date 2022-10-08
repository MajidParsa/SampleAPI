using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Domain.SeedWork;

namespace Blog.Domain.AggregatesModel
{
    public class Post: BaseEntity
    {
        public string content { get; private set; }
        public DateTime CreateDate { get; private set; }
        public int BlogId { get; private set; }
        public Blog Blog { get; private set; }
    }
}
