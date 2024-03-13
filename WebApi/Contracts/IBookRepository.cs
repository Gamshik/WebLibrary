using Entities;

namespace Contracts
{
    public interface IBookRepository
    {
        void CreateBookPreview(BookPreview bookPreview);
        void CreateTextOfBook(TextOfBook textOfBook);
        IQueryable<BookPreview> GetAllBookPreviews();
        TextOfBook? GetTextOfBook(int bookId);
    }
}
