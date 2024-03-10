using AutoMapper;
using Domain.Classes.DTOs.BookDTOs;
using Domain.Classes.Entities;

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
