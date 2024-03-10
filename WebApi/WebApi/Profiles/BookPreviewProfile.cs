using AutoMapper;
using Domain.Classes.DTOs.BookDTOs;
using Domain.Classes.Entities;

namespace WebApi.Profiles
{
    public class BookPreviewProfile : Profile
    {
        public BookPreviewProfile()
        {
            CreateMap<BookPreviewCreateDto, BookPreview>().ForMember("Cover", opt => opt.MapFrom(b => Convert.FromBase64String(b.Cover)));
            CreateMap<BookPreview, BookPreviewDto>();
        }
    }
}
