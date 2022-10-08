using AutoMapper;
using Blog.Application;

namespace Blog.API.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void InitializeAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
