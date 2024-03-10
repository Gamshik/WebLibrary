using Domain.Classes.Entities;

namespace Domain.Interfaces
{
    public interface IBookRepository
    {
        void CreateBookPreview(BookPreview bookPreview);
        void CreateTextOfBook(TextOfBook textOfBook);
        IQueryable<BookPreview> GetAllBookPreviews();
        TextOfBook? GetTextOfBook(int bookId);
    }
}
