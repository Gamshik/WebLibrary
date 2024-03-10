using Domain.Classes.Entities;
using Domain.Context;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Classes.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationContext _context;
        public BookRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void CreateBookPreview(BookPreview bookPreview)
        {
            _context.BooksPreviews.Add(bookPreview);
            SaveChanges();
        }

        public void CreateTextOfBook(TextOfBook textOfBook)
        {
            _context.TextsOfBooks.Add(textOfBook);
            SaveChanges();
        }

        public IQueryable<BookPreview> GetAllBookPreviews()
        {
            return _context.BooksPreviews.AsNoTracking();
        }

        public TextOfBook? GetTextOfBook(int bookId)
        {
            return _context.TextsOfBooks.AsNoTracking().SingleOrDefault(t => t.BookId == bookId);
        }

        private void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
