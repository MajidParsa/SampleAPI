using Blog.Infrastructure.Repositories.Blog;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient(typeof(IBlogRepository), typeof(BlogRepository));

            return services;
        }
    }
}
