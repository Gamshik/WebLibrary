using Domain.Classes.DTOs.BookDTOs;
using Domain.Classes.Entities;
using Domain.Classes.Parameters;

namespace Domain.Interfaces
{
    public interface IBookService
    {
        Result CreateBookPreview(BookPreviewCreateDto bookPreviewCreateDto);
        Result CreateTextOfBook(TextOfBookCreateDto textOfBookCreateDto);
        Dictionary<string, BookPreviewDto> GetAllBookPreviews();
        PagedList<char> GetTextOfPage(int bookId, PagingParameters parameters);
    }
}
