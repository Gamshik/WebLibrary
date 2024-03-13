namespace Entities.DTOs.BookDTOs
{
    public class BookPreviewCreateDto
    {
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Author { get; set; }
        public string? Description { get; set; }
    }
}
