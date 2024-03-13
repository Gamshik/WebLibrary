using AutoMapper;
using Entities;
using Entities.DTOs.BookDTOs;

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
