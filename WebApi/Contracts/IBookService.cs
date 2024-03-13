using Entities;
using Entities.DTOs.BookDTOs;
using Entities.Parameters;

namespace Contracts
{
    public interface IBookService
    {
        Result CreateBookPreview(BookPreviewCreateDto bookPreviewCreateDto);
        Result CreateTextOfBook(TextOfBookCreateDto textOfBookCreateDto);
        Dictionary<int, BookPreviewDto> GetAllBookPreviews();
        PagedList<char> GetTextOfPage(int bookId, PagingParameters parameters);
    }
}
