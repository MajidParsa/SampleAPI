
using Blog.Domain.AggregatesModel;
using Blog.Infrastructure.Repositories.EF;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repositories.Blog
{
    public class BlogRepository : BaseRepository<Domain.AggregatesModel.Blog>, IBlogRepository
    {
        private DbSet<Post> PostEntities { get; }

        public BlogRepository(BlogDBContext dbContext) : base(dbContext)
        {
            PostEntities = DbContext.Set<Post>();
        }
        
        public async Task PutCommentAsync(Domain.AggregatesModel.Blog blog, Post post, CancellationToken cancellationToken, bool saveNow = true)
        {
            await base.UpdateAsync(blog, cancellationToken);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task UpdateBlogAsync(Domain.AggregatesModel.Blog blog, Post post, CancellationToken cancellationToken, bool saveNow = true)
        {
            await base.UpdateAsync(blog, cancellationToken);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Domain.AggregatesModel.Blog>> SelectBlogsLast10Days(int userId, CancellationToken cancellationToken)
        {
            var result = await TableNoTracking
                .Where(i => i.CreatorId == userId && i.CreateDate >= DateTime.Now.AddDays(-10))
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<IEnumerable<Domain.AggregatesModel.Blog>> SelectPostsLast30DaysOfBlogs(int userId, CancellationToken cancellationToken)
        {
            var result = await TableNoTracking
                .Include(p => p.Posts)
                .Where(i => i.CreatorId == userId)
                .Where(p => p.Posts.Any(t => t.CreateDate >= DateTime.Now.AddDays(-30)))
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<IEnumerable<Domain.AggregatesModel.Blog>> SelectBlogsAsync(int? blogId, int userId, CancellationToken cancellationToken)
        {
            var result = await TableNoTracking
                .Include(p=>p.Posts)
                .ThenInclude(c=> c.Comments)
                .Where(i => (blogId == null || i.Id == blogId) && i.CreatorId == userId)
                .ToListAsync(cancellationToken);

            return result;
        }
    }
}
