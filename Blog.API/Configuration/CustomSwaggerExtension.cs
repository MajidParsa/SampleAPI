using Microsoft.OpenApi.Models;

namespace Blog.API.Configuration
{
    public static class CustomSwaggerExtension
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            // Register the Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Blog.API",
                    Version = "V1",
                    Description = "Matrix42 Work Trial Task",
                });
            });

            return services;
        }

    }
}
