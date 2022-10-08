using Blog.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Application.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IBlogService, BlogService>();
            return services;
        }
    }
}
