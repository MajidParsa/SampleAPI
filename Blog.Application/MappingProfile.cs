using AutoMapper;
using Blog.Application.DTOs;

namespace Blog.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogDto, Domain.AggregatesModel.Blog>().ReverseMap();
            CreateMap<Domain.AggregatesModel.Blog, List<BlogDto>>().ReverseMap();
            CreateMap<Domain.AggregatesModel.Blog, Domain.AggregatesModel.Blog>().ReverseMap();
            CreateMap<BlogUpdateCommand, Domain.AggregatesModel.Blog>().ReverseMap();
            CreateMap<Domain.AggregatesModel.Blog, BlogsDto>();
        }
    }
}
