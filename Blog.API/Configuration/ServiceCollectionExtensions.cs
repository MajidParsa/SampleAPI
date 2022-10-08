using Blog.Application;
using Blog.Application.Services;
using Blog.Infrastructure.Repositories.Blog;

namespace Blog.API.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBlogService, BlogService>();
            services.AddTransient<IBlogRepository, BlogRepository>();
        }
    }
}
