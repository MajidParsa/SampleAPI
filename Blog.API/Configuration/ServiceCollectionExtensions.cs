using Blog.Application;
using Blog.Application.Services;

namespace Blog.API.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBlogService, BlogService>();
        }
    }
}
