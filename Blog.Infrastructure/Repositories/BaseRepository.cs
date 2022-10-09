using Blog.Domain.SeedWork;
using Blog.Infrastructure.Repositories.EF;
using Blog.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        protected readonly BlogDBContext DbContext;
        public IUnitOfWork UnitOfWork => DbContext;
        private DbSet<TEntity> Entities { get; }
        public IQueryable<TEntity> Table => Entities;
        public IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        public BaseRepository(BlogDBContext dbContext)
        {
            DbContext = dbContext;
            Entities = DbContext.Set<TEntity>();
        }

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            await Entities.AddAsync(entity, cancellationToken).ConfigureAwait(false);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public virtual async Task<TEntity?> GetByIdAsync(CancellationToken cancellationToken, params object[] ids)
        {
            var tEntity = await Entities.FindAsync(ids, cancellationToken);
            return tEntity;
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true)
        {
            Assert.NotNull(entity, nameof(entity));
            Entities.Update(entity);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken);
        }



    }
}
