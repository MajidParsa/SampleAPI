using Blog.Domain.SeedWork;

namespace Blog.Infrastructure.Repositories
{
    public abstract class BaseEntity<TKey> : IEntity
    {
        public TKey Id { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }
}
