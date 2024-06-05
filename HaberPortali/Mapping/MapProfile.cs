using HaberPortali.Dtos;
using HaberPortali.Models;
using AutoMapper;
namespace HaberPortali.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<News, NewsDto>().ReverseMap();
            CreateMap<Models.File, FileDto>().ReverseMap();
            //CreateMap<Models.File, GetFileDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();
        }
    }
}
