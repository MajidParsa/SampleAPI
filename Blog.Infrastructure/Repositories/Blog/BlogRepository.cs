
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

        public async Task<Domain.AggregatesModel.Blog?> SelectBlogAsync(int id, CancellationToken cancellationToken)
        {
            //var blog = _blogs.FirstOrDefault(i => i.Id == id);
            //return await Task.Run(() => blog, cancellationToken);
            return null;
        }

        public async Task<IEnumerable<Domain.AggregatesModel.Blog>> SelectBlogsAsync(CancellationToken cancellationToken)
        {
            return null;//await Task.Run(() => _blogs, cancellationToken);
        }

        //public async Task<Domain.AggregatesModel.Blog> InsertBlogAsync(Domain.AggregatesModel.Blog blog, CancellationToken cancellationToken)
        //{
        //    _blogs.Add(blog);
        //    return await Task.Run(() => blog, cancellationToken);
        //}

        public async Task<Domain.AggregatesModel.Blog> UpdateBlogAsync(Domain.AggregatesModel.Blog blog, CancellationToken cancellationToken)
        {
            return null;
            //_ = _blogs.Remove(_blogs.First(i => i.Id == blog.Id));
            //_blogs.Add(blog);
            //return await Task.Run(() => blog, cancellationToken);
        }

        public async Task PutCommentAsync(Domain.AggregatesModel.Blog blog, Post post, CancellationToken cancellationToken, bool saveNow = true)
        {
            await base.UpdateAsync(blog, cancellationToken);
            if (saveNow)
                await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            //Event eventInstance = expense.Event;
            //expense.ExpensePartTakers.Add(expenseParticipant);
            //await base.UpdateAsync(eventInstance, cancellationToken);
            //if (saveNow)
            //    await DbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
