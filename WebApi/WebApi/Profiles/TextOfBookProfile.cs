using AutoMapper;
using Entities;
using Entities.DTOs.BookDTOs;

namespace WebApi.Profiles
{
    public class TextOfBookProfile : Profile
    {
        public TextOfBookProfile()
        {
            CreateMap<TextOfBookCreateDto, TextOfBook>();
        }
    }
}
