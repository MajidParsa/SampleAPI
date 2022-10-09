using AutoMapper;
using Blog.Application.DTOs;

namespace Blog.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogPostDto, Domain.AggregatesModel.Blog>().ReverseMap();
            CreateMap<Domain.AggregatesModel.Blog, List<BlogPostDto>>();
            CreateMap<Domain.AggregatesModel.Blog, BlogsDto>();
        }
    }
}
