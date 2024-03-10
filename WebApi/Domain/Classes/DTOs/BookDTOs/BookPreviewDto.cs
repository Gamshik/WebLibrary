namespace Domain.Classes.DTOs.BookDTOs
{
    public class BookPreviewDto
    {
        public byte[] Cover { get; set; }
        public string Author { get; set; }
        public string? Description { get; set; }
    }
}
