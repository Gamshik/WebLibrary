namespace Domain.Classes.DTOs.BookDTOs
{
    public class BookPreviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public byte[] Cover { get; set; }
        public string Author { get; set; }
        public string? Description { get; set; }
    }
}
