using System.Reflection;
using Blog.Application.Commands.BlogCommands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Application.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddBlogCommandHandler).GetTypeInfo().Assembly);

            return services;
        }
    }
}
