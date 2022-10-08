using AutoMapper;
using Blog.Application.DTOs;
using Blog.Infrastructure.Repositories.Entities;

namespace Blog.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BlogDto, BlogEntity>().ReverseMap();
        }
    }
}
