using Blog.Domain.SeedWork;
using Blog.Infrastructure.Repositories;
using Blog.Infrastructure.Repositories.Blog;
using Blog.Infrastructure.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient(typeof(IBlogRepository), typeof(BlogRepository));

            //EF :
            services.AddDbContext<BlogDBContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(BlogDBContext).Assembly.FullName)));


            return services;
        }
    }
}
